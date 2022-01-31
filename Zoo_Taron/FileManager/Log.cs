using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo_Taron.FileManager
{
    class Log
    {
        private static Log _instance;
        private Log()
        {

        }
        public void Write(string s)
        {

        }
        public static Log GetInstance()
        {
            if (_instance == null) _instance = new Log();
            return _instance;
        }
    }
}
