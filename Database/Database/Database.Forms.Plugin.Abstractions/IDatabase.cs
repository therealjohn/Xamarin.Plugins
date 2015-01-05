using System;
using SQLite.Net.Async;

namespace Database.Forms.Plugin.Abstractions
{
    /// <summary>
    /// Database Interface
    /// </summary>
    public interface IDatabase
    {
        SQLiteAsyncConnection GetConnection(string databaseFileName);
    }
}
