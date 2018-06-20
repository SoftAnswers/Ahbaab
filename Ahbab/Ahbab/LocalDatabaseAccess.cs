using Asawer.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asawer
{
    public class LocalDatabaseAccess
    {
        public static string StatusMessage = string.Empty;
        protected SQLiteAsyncConnection connection;

        public LocalDatabaseAccess(string dbPath)
        {
            this.connection = new SQLiteAsyncConnection(dbPath);
        }

        public async Task<int> InsertItemsToDatabaseAsync<T>(IList<T> items)
        {
            return await this.connection.InsertAllAsync(items);
        }

        public async Task<int> InsertItemAsync<T>(T item)
        {
            if (item == null)
                throw new NullReferenceException();

            return await this.connection.InsertAsync(item);
        }

        public static int InsertItemsToDatabase<T>(string dbPath, IList<T> items)
        {
            try
            {
                using (var sqlConnection = new SQLiteConnection(dbPath))
                {
                    return sqlConnection.InsertAll(items);
                }
            }
            catch
            {
                return 0;
            }
        }

        public static bool InsertItem<T>(SQLiteConnection connection, T item)
        {
            if (item == null)
                throw new NullReferenceException();

            var result = connection.Insert(item);

            return result > 0 ? true : false;
        }

        public static List<T> GetAllItems<T>(string dbPath)
            where T : DbObject, new()
        {
            using (var connection = new SQLiteConnection(dbPath))
            {
                try
                {
                    return connection.Table<T>().ToList();
                }
                catch (Exception ex)
                {
                    StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
                }

                return new List<T>(); 
            }
        }

        public static void CreateTable<T>(string dbPath)
        {
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.CreateTable<T>();
            }
        }
    }
}
