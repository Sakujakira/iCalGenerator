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
            CallObject a = new CallObject();
            a = Validation.ValidateAll(args);
            if (a.ChecksSolved)
            {
                Generator.create(a.Path, a.Seperator);
            }
        }
    }
}
