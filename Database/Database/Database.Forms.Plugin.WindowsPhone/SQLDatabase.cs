using System;
using System.IO;
using Xamarin.Forms;
using Database.Forms.Plugin.WindowsPhone;
using Database.Forms.Plugin.Abstractions;
using SQLite.Net;
using SQLite.Net.Async;
using Windows.Storage;

[assembly: Dependency(typeof(SQLDatabase))]
namespace Database.Forms.Plugin.WindowsPhone
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
            string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, databaseFileName);

            var platform = new SQLite.Net.Platform.WindowsPhone8.SQLitePlatformWP8();

            var connectionWithLock = new SQLiteConnectionWithLock(platform, new SQLiteConnectionString(path, true));

            var connection = new SQLiteAsyncConnection(() => connectionWithLock);

            return connection;
        }
    }
}
