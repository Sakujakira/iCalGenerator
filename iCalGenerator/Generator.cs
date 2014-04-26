using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDay.iCal;
using DDay.iCal.Serialization.iCalendar;

namespace iCalGenerator
{
    static class Generator
    {

        internal static void create(string filepath, char sep)
        {
            string[] events = getEvents(filepath);

            for (int i = 0; i < events.Length; i++)
            {
                EventUIDCheckAndGenerate(filepath, sep, i);
                string[] tmpEvent = events[i].Split(sep);
                writeEvent(tmpEvent, i);
            }
        }

        private static void EventUIDCheckAndGenerate(string filepath, char sep, int i)
        {
            
        }

        private static void writeEvent(string[] tmpEvent, int count)
        {
            iCalendar iCal = new iCalendar
            {
                Method = "Publish",
                Version = "2.0"
            };
            iCal.AddLocalTimeZone();
            var evt = iCal.Create<Event>();
            //Titel
            evt.Summary = tmpEvent[0];
            //Beschreibung
            evt.Description = tmpEvent[1];
            //Raum/Ort
            evt.Location = tmpEvent[2];
            //Versuchte Zeit
            try
            {
                evt.Start = new iCalDateTime(DateTime.Parse(tmpEvent[3]));
            } catch(FormatException)
            {
                Console.WriteLine("ERROR: Das Datum unterliegt aktuell leider strengen Einschränkungen.");
            }
            //Ende
            int dauer = Int16.Parse(tmpEvent[4]);
            evt.End = evt.Start.AddMinutes(dauer);
            //Ganztägig?
            evt.IsAllDay = Boolean.Parse(tmpEvent[5]);
            //Kontaktmail
            evt.Organizer = new Organizer(tmpEvent[6]);
            evt.UID = setUID(tmpEvent, count);
            try
            {

                System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Test\" + tmpEvent[0].Substring(0, 15) + ".ics", false, System.Text.Encoding.UTF8);
                file.WriteLine(new iCalendarSerializer().SerializeToString(iCal));
                file.Close();
                Console.WriteLine(tmpEvent[0].Substring(0, 15) + ".ics erzeugt");
            }
            catch (Exception)
            {
                Console.WriteLine("INFO: Veranstaltungsname kürzer als 15 Zeichen, verwende vollen Namen.");
                System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Test\" + tmpEvent[0].Substring(0, tmpEvent[0].Length) + ".ics", false, System.Text.Encoding.UTF8);
                file.WriteLine(new iCalendarSerializer().SerializeToString(iCal));
                file.Close();
                Console.WriteLine(tmpEvent[0].Substring(0, tmpEvent[0].Length) + ".ics erzeugt");
            }
            
            
        }

        private static string setUID(String[] a, int count)
        {
            String uid;

            try
            {
                uid = a[7];
                Console.WriteLine("INFO: UID vorhanden, verwende bekannte UID " + uid);
            }
            catch (Exception)
            {
                uid = Guid.NewGuid().ToString();
                Console.WriteLine("INFO: UID unbekannt, habe neue UID erzeugt " + uid);
            }
            return uid;
        }

        private static string[] getEvents(string filepath)
        {
            string line;
            List<String> events = new List<String>();

            System.IO.StreamReader file = new System.IO.StreamReader(filepath,System.Text.Encoding.Default);
            while ((line = file.ReadLine()) != null)
            {
                events.Add(line);
            }

            file.Close();

            return events.ToArray<String>();
        }
    }
}
