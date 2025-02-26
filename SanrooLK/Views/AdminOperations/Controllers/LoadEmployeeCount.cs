using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Threading.Tasks;

namespace SanrooLK.Views.AdminOperations.Controllers
{
    class LoadEmployeeCount
    {
        private static string connectionString = "mongodb+srv://DesktopClient:6uJegLlg5cjVy5GS@sanroolk.xxwnk.mongodb.net/?retryWrites=true&w=majority&appName=SanrooLK";
        private static string databaseName = "SanrooLKDB";
        private static string collectionName = "Employee";

        public static async Task<int> GetEmployeeCount()
        {
            try
            {
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase(databaseName);
                var collection = database.GetCollection<BsonDocument>(collectionName);

                return (int)await collection.CountDocumentsAsync(FilterDefinition<BsonDocument>.Empty);
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
