using System;
using Database.Plugin.Abstractions;
using SQLite;

namespace Database.Plugin
{
  /// <summary>
  /// Implementation for Feature
  /// </summary>
  public class DatabaseImplementation : IDatabase
  {
      public SQLiteConnection GetConnection(string databaseFileName)
      {
          string folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
          var connection = new SQLiteConnection(System.IO.Path.Combine(folder, databaseFileName));

          return connection;
      }
  }
}