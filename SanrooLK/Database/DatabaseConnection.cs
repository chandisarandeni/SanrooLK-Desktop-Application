using MongoDB.Driver;
using System;

namespace SanrooLK.Database
{
    internal class DatabaseConnection
    {
        private static string connectionString = "mongodb+srv://DesktopClient:6uJegLlg5cjVy5GS@sanroolk.xxwnk.mongodb.net/?retryWrites=true&w=majority&appName=SanrooLK";
        private static string databaseName = "SanrooLKDB";

        // Method to get the MongoDB client and database connection
        public static IMongoDatabase GetDatabaseConnection()
        {
            // Create a MongoDB client with the connection string
            var client = new MongoClient(connectionString);

            // Get and return the database connection
            var database = client.GetDatabase(databaseName);
            return database;
        }
    }
}
