using System;
using System.IO;
using Xamarin.Forms;
using Database.Forms.Plugin.iOS;
using Database.Forms.Plugin.Abstractions;
using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Platform.XamarinIOS;

[assembly: Dependency(typeof(SQLDatabase))]
namespace Database.Forms.Plugin.iOS
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
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, databaseFileName);

            var platform = new SQLitePlatformIOS();

            var connectionWithLock = new SQLiteConnectionWithLock(platform, new SQLiteConnectionString(path, true));

            var connection = new SQLiteAsyncConnection(() => connectionWithLock);

            return connection;
        }
    }
}
