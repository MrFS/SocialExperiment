using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;

namespace Core
{
    public class vController

    {
        public vController()
        {

            if (Debugger.IsAttached)
            {

                DataTable dt = new DataTable("Version Controller");

                _Major = 1;

                _Minor = 0;

                _Build = 0;

                _Revision = 0;
            }
            

            
           
        }
        

        private int _Major;

        private int _Minor;

        private int _Build;

        private int _Revision;


        public int Major
        {
            get
            {
                return _Major;

            }
        }

        public int Minor
        {
            get
            {
                return _Minor;
            }
        }

        public int Build
        {
            get
            {
                return _Build;
            }
        }

        public int Revision
        {
            get
            {
                return _Revision;
            }
        }

    }
}
