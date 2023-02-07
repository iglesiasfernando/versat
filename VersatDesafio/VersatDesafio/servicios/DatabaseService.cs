using System;
using System.Diagnostics;
using Xamarin.Forms;
using SQLite;
using System.IO;

namespace VersatDesafio.Services
{
    
        public class DatabaseService
        {
            public SQLiteAsyncConnection Database { get; } = new SQLiteAsyncConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
            public static String DATABASE_NAME = "VersatDesafio.db3";

            public DatabaseService()
            {

            }
            public DatabaseService(string deviceDbPath)
            {
                
            }
        }
}
