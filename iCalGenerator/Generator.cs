using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCalGenerator
{
    static class Generator
    {

        internal static void create(string filepath)
        {
            string[] events = getEvents(filepath);
            int seperater = 0;
            seperater = Validation.guess(events[0]);
            if (seperater == 1)
            {
                //Der Trenner scheint ein ; zu sein
                for (int i = 0; i < events.Length; i++)
                {
                }
            }
                // der Trenner scheint ein , zu sein
            else if (seperater == 2)
            {
                for (int i = 0; i < events.Length; i++)
                {
                }
            }
        }

        private static string[] getEvents(string filepath)
        {
            string line;
            List<String> events = new List<String>();

            System.IO.StreamReader file = new System.IO.StreamReader(filepath);
            while ((line = file.ReadLine()) != null)
            {
                events.Add(line);
            }

            file.Close();

            return events.ToArray<String>();
        }
    }
}
