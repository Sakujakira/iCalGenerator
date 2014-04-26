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
        private static CallObject A = new CallObject();
                
        internal static CallObject ValidateAll(string[] args){

            //validieren das mindestens 2 Parameter mitgegeben sind.
            if (commandLength(args))
            {
                Console.WriteLine("INFO: Mindestanzahl Parameter erfüllt");
                //validieren das alle Parameter gültig sind
                if (paramValidation(args))
                {
                    Console.WriteLine("INFO: Parameter sind gültig.");
                    if (extensionValidation(A.Path))
                    {
                        if (fileexists(A.Path))
                        {
                            A.ChecksSolved = true;
                            return A;
                        }
                    }
                    else
                    {
                        Console.WriteLine("ERROR: Prüfung auf Dateiendung nicht bestanden.");
                    }

                }
                else
                {
                    Console.WriteLine("ERROR: Parameter ungültig.");
                }
            }
            else
            {
                Console.WriteLine("ERROR: Zu wenig Parameter. Pflichtparameter sind /F und /S.");
            }
           
            return A;
        }

        private static bool commandLength(String[] args)
        {
            try
            {
                if (args.Length < 2)
                {

                    if (args[0] == "/H")
                    {
                        printHelp(new CallObject());
                        return false;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("ERROR: Zu wenig Parameter. Pflichtparameter sind /F und /S oder versuchen Sie es mit /H");
            }
            return false;
        }

        private static bool paramValidation(String[] args){
            string param;
            
            for (int i = 0; i < args.Length; i++)
            {
                param = extractParam(args[i]);
                switch (param)
                {
                    case "/F":
                        Console.WriteLine("INFO: File Parameter gefunden.");
                        A.Path = extractFile(args[i]);
                        break;
                    case "/S":
                        Console.WriteLine("INFO: Seperator Parameter gefunden.");
                        A.Seperator = extractSeperator(args[i]);
                        break;
                    /*case "/H":
                        Console.WriteLine("INFO: Hilfe Parameter gefunden");
                        printHelp(a);
                        break;*/
                    default:
                        Console.WriteLine("ERROR: Mindestens ein falscher Parameter: " + param);
                        break;
                }
            }
            return true;
        }

        private static void printHelp(CallObject a)
        {
            Console.WriteLine(a.Help);
        }

        private static char extractSeperator(String s)
        {
            String seperator = "";
            try
            {
                seperator = s.Split('=')[1];
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("ERROR: Kein korrekter Trenner angegeben.");
                Environment.Exit(0);
            }
            return seperator.ToCharArray()[0];
        }

        private static String extractFile(String s)
        {
            String filepath = "";
            try
            {
                filepath = s.Split('=')[1];
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("ERROR: Kein korrekter Dateipfad angegeben.");
                Environment.Exit(0);
            }
            return filepath;
            
            
        }
        private static String extractParam(String s)
        {
            return s.Split('=')[0];
        }


        internal static bool extensionValidation(String filepath) 
        {
            bool returnValue = false;
            try
            {
                string dateiendung = filepath.Substring(filepath.Length - 3);
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

        internal static bool fileexists(String file)
        {
            bool returnValue = false;
            try
            {
                if (File.Exists(file))
                {
                    Console.WriteLine("INFO: Eingabedatei vorhanden.");
                    returnValue = true;
                }
                else throw new Exception();
            }
            catch (Exception)
            {
                Console.WriteLine("ERROR: Fehler beim oeffnen der Datei. Pfad und Dateiname korrekt?");
            }
            return returnValue;
        }
    }
}
