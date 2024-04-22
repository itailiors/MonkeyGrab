using System;


namespace MonkeyGrab
{
    class SQLhelper
    {
        private const string DB_FILE_NAME = "CardB";

        public static string Path()
        {
            string dbFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string path = System.IO.Path.Combine(dbFolderPath, DB_FILE_NAME);
            return path;
        }
    }
}