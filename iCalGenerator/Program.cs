using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCalGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Prüfen wieviele Argumente mitgegeben wurden, und ob die Anzahl der erwartetetn entspricht.
            if (Validation.argValidation(args))
            {
                if (Validation.extensionValidation(args))
                {
                    if (Validation.fileexists(args[0]))
                    {
                        Generator.create(args[0]);
                    }
                }
            }
        }
    }
}
