using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SanrooLK.Views.AdminOperations.Controllers
{
    public static class LoadCheckoutData
    {
        private static string connectionString = "mongodb+srv://DesktopClient:6uJegLlg5cjVy5GS@sanroolk.xxwnk.mongodb.net/?retryWrites=true&w=majority&appName=SanrooLK";
        private static string databaseName = "SanrooLKDB";
        private static string collectionName = "Checkout";

        public static async Task<List<Checkout>> GetCheckoutDetails()
        {
            try
            {
                // Create a MongoClient to connect to MongoDB
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase(databaseName);
                var collection = database.GetCollection<BsonDocument>(collectionName);

                // Fetch all documents from the Checkout collection
                var checkoutDocuments = await collection.Find(FilterDefinition<BsonDocument>.Empty).ToListAsync();

                if (checkoutDocuments.Count == 0)
                {
                    Console.WriteLine("No checkout data found.");
                }

                // Convert the BsonDocument to Checkout objects
                List<Checkout> checkoutList = new List<Checkout>();

                foreach (var doc in checkoutDocuments)
                {
                    // Ensure that each field exists before accessing it
                    checkoutList.Add(new Checkout
                    {
                        CheckoutID = doc.Contains("checkoutID") ? doc["checkoutID"].AsString : string.Empty,
                        CheckoutDate = doc.Contains("checkoutDate") ? doc["checkoutDate"].ToString() : string.Empty,
                        UnitTotal = doc.Contains("unitTotal") ? doc["unitTotal"].ToDouble() : 0.0,
                        DiscountPrice = doc.Contains("discountPrice") ? doc["discountPrice"].ToDouble() : 0.0,
                        FinalPrice = doc.Contains("finalPrice") ? doc["finalPrice"].ToDouble() : 0.0
                    });
                }

                return checkoutList;
            }
            catch (Exception ex)
            {
                // Log the error in more detail
                Console.WriteLine($"Error fetching checkout data: {ex.Message}");
                Console.WriteLine(ex.StackTrace); // Logs full exception details
                return new List<Checkout>(); // Return an empty list in case of error
            }
        }
    }
}
