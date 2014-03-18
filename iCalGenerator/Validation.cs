using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCalGenerator
{
    static class Validation
    {
        
        internal static Boolean argValidation(string[] args){
            
            bool returnValue = false; 

            if (args.Length < 1)
            {
                Console.WriteLine("ERROR: Zu wenig Parameter, bitte mindestens die Dateipfad Angabe mitgeben.");
            }
            else if (args.Length > 1)
            {
                Console.WriteLine("ERROR: Aktuell wird als einziger Paramter ein Dateipfad unterstützt.");
            }
            else
            {
                //Alle Prüfungen bestanden.
                returnValue = true;
            }
            Console.WriteLine("INFO: Paramater Anzahl ist korrekt.");
            return returnValue;
        }

        internal static bool extensionValidation(string[] args) 
        {
            bool returnValue = false;
            try
            {
                string dateiendung = args[0].Substring(args[0].Length - 3);
                if (String.Equals(dateiendung, "csv"))
                {
                    returnValue = true;
                }
                else
                {
                    throw new NotSupportedException();
                }
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("ERROR: Dieser Dateityp wird aktuell nicht unterstützt.");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("ERROR: Dateiname zu kurz um eine CSV zu sein.");
            }
            Console.WriteLine("INFO: Dateityp korrekt.");
            return returnValue;
        }

        internal static bool fileexists(string file)
        {
            bool returnValue = false;
            try
            {
                if (File.Exists(file))
                    returnValue = true;
                else throw new Exception();
            }
            catch (Exception)
            {
                Console.WriteLine("ERROR: Fehler beim oeffnen der Datei. Pfad und Dateiname korrekt?");
            }
            Console.WriteLine("INFO: Datei vorhanden.");
            return returnValue;
        }

        internal static int guess(string line)
        {
            string[] a = line.Split(';');
            string[] b = line.Split(',');
            if (a.Length > b.Length)
                return 1;
            else
                return 2;
        }
    }
}
