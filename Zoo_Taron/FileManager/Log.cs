using System;
using System.IO;

namespace Zoo_Taron
{
    class Log
    {
        private static Log _instance;
        private static DateTime Date;
        private static string FileAdress = @$"./Log{Date.ToString("dd")}.txt";

        public Log()
        {
            Date = DateTime.Now;
        }
        public void Write(string s)
        {
            CheckOrChangeDate();
            using StreamWriter writer = new(new FileStream(FileAdress, FileMode.Append, FileAccess.Write));
            writer.WriteLine(s + " " + DateTime.Now.ToString());
        }

        private void CheckOrChangeDate()
        {
            if (Date.Day != DateTime.Now.Day) Date = DateTime.Now;
        }
        public static Log GetInstance()
        {
            if (_instance == null) _instance = new Log();
            return _instance;
        }
    }
}
