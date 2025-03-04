using MongoDB.Driver;
using SanrooLK.Views.AdminOperations.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SanrooLK.Views.AdminOperations.Controllers
{
    public class LoadInquiries
    {
        private static readonly string connectionString = "mongodb+srv://DesktopClient:6uJegLlg5cjVy5GS@sanroolk.xxwnk.mongodb.net/?retryWrites=true&w=majority&appName=SanrooLK";
        private static readonly string databaseName = "SanrooLKDB";
        private static readonly string collectionName = "Inquiry";

        public static async Task<List<Inquiry>> GetInquiriesAsync()
        {
            try
            {
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase(databaseName);
                var collection = database.GetCollection<Inquiry>(collectionName);

                var inquiries = await collection.Find(FilterDefinition<Inquiry>.Empty).ToListAsync();

                Debug.WriteLine($"MongoDB Inquiries Fetched: {inquiries.Count}");
                return inquiries;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"MongoDB Error: {ex.Message}");
                return new List<Inquiry>();
            }
        }
    }
}
