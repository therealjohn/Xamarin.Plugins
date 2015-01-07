using System;
using System.IO;
using Database.Plugin.Abstractions;
using SQLite;


namespace Database.Plugin
{
  /// <summary>
  /// Implementation for Database
  /// </summary>
  public class DatabaseImplementation : IDatabase
  {
      public SQLiteConnection GetConnection(string databaseFileName)
      {
          string folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
          var libraryPath = Path.Combine(folder, "..", "Library");

          var connection = new SQLiteConnection(Path.Combine(libraryPath, databaseFileName));

          return connection;
      }
  }
}