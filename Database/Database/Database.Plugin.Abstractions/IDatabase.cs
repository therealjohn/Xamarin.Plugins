using System;
using SQLite;

namespace Database.Plugin.Abstractions
{
  /// <summary>
  /// Interface for Database
  /// </summary>
  public interface IDatabase
  {
       SQLiteConnection GetConnection(string databaseFileName);
  }
}
