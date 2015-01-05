using System;
using System.IO;
using Xamarin.Forms;
using Database.Forms.Plugin.Droid;
using Database.Forms.Plugin.Abstractions;
using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Platform.XamarinAndroid;

[assembly: Dependency(typeof(SQLDatabase))]
namespace Database.Forms.Plugin.Droid
{
    /// <summary>
    /// Database Implementation
    /// </summary>
    public class SQLDatabase : IDatabase
    {
        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        public static void Init() { }

        public SQLiteAsyncConnection GetConnection(string databaseFileName)
        {
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, databaseFileName);

            var platform = new SQLitePlatformAndroid();

            var connectionWithLock = new SQLiteConnectionWithLock(platform, new SQLiteConnectionString(path, true));

            var connection = new SQLiteAsyncConnection(() => connectionWithLock);

            return connection;
        }
    }
}
