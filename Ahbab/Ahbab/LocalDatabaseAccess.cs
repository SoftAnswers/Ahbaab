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

        public static bool InsertItemsToDatabase<T>(string dbPath, IList<T> items)
        {
            var retVal = false;

            using (var connection = new SQLiteConnection(dbPath))
            {
                foreach (T item in items)
                {
                    retVal = InsertItem(connection, item);
                }
            }

            return retVal;
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
                    var type = typeof(T).GetType();

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
