using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanrooLK.Database
{
    internal class DatabaseConnection
    {
        private static string connectionString = "mongodb+srv://DesktopClient:6uJegLlg5cjVy5GS@sanroolk.xxwnk.mongodb.net/";
        private static string databaseName = "SanrooLKDB";

        public static IMongoDatabase GetDatabase()
        {
            var client = new MongoClient(connectionString);
            return client.GetDatabase(databaseName);
        }
    }
}
