using System;
using Database.Plugin.Abstractions;
using SQLite;
using Windows.Storage;

namespace Database.Plugin
{
  /// <summary>
  /// Implementation for Database
  /// </summary>
  public class DatabaseImplementation : IDatabase
  {
      public SQLiteConnection GetConnection(string databaseFileName)
      {
          string folder = ApplicationData.Current.LocalFolder.Path;
          var connection = new SQLiteConnection(System.IO.Path.Combine(folder, databaseFileName));

          return connection;
      }
  }
}