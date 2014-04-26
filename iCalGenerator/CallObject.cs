using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCalGenerator
{
    class CallObject
    {
        //Speicherklasse für die mitgelieferten Aufrufsparameter
        internal char _seperator;
        internal String _path;
        internal String _help;
        internal Boolean _checksSolved = false;

        public CallObject()
        {
            _path = "";
            _seperator = new char();
            _help = "iCalGenerator /F='filepath' /S='seperator' /H \n"+
                "\n"+
                "/F='filepath' \t specifies the file using to generate multiple iCal Events.\n\n"+
                "/S='seperator' \t specifies the seperator used to cut different fields in the given file.\n\n"+
                "/H \t prints this help.";

        }

        public String Path
        {
            set { this._path = value; }
            get { return this._path; } 
        }

        public String Help
        {
            set { this._help = value; }
            get { return this._help; }
        }

        public char Seperator
        {
            set { this._seperator = value; }
            get { return this._seperator; }
        }

        public Boolean ChecksSolved
        {
            set { this._checksSolved = value; }
            get { return this._checksSolved; }
        }
    }
}
