using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SanrooLK.Views.AdminOperations.Controllers;
using SanrooLK.Views.AdminOperations.Views;

namespace SanrooLK.Views.AdminOperations.Controllers
{
    public static class LoadSalesData
    {
        private static string connectionString = "mongodb+srv://DesktopClient:6uJegLlg5cjVy5GS@sanroolk.xxwnk.mongodb.net/?retryWrites=true&w=majority&appName=SanrooLK";
        private static string databaseName = "SanrooLKDB";

        public static async Task<List<Sale>> GetSalesDetails()
        {
            try
            {
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase(databaseName);

                // Get Order Collection
                var orderCollection = database.GetCollection<BsonDocument>("Order");

                // Get Payment Collection
                var paymentCollection = database.GetCollection<BsonDocument>("Payment");


                // Get Checkout Collection
                var checkoutCollection = database.GetCollection<BsonDocument>("Checkout");

                // Get Product Collection
                var productCollection = database.GetCollection<BsonDocument>("Product");

                var salesDetails = new List<Sale>();

                // Fetch orders
                var orders = await orderCollection.Find(FilterDefinition<BsonDocument>.Empty).ToListAsync();

                foreach (var order in orders)
                {
                    // 1. Get Payment ID from Order collection
                    var paymentID = order["PaymentID"].AsString;

                    // 2. Get Checkout ID from Payment collection
                    var payment = await paymentCollection.Find(Builders<BsonDocument>.Filter.Eq("PaymentID", paymentID)).FirstOrDefaultAsync();
                    if (payment == null) continue;

                    var checkoutID = payment["CheckoutID"].AsString;

                    // 3. Get Product ID from Checkout collection
                    var checkout = await checkoutCollection.Find(Builders<BsonDocument>.Filter.Eq("CheckoutID", checkoutID)).FirstOrDefaultAsync();
                    if (checkout == null) continue;

                    var productID = checkout["ProductID"].AsString;

                    // 4. Get Product details from Product collection
                    var product = await productCollection.Find(Builders<BsonDocument>.Filter.Eq("ProductID", productID)).FirstOrDefaultAsync();
                    if (product == null) continue;

                    // Map the data to Sale object
                    salesDetails.Add(new Sale
                    {
                        ProductID = product["ProductID"].AsString,
                        ProductName = product["ProductName"].AsString,
                        CustomerID = order["CustomerID"].AsString,
                        Quantity = checkout["Quantity"].AsInt32,
                        FinalPrice = checkout["FinalPrice"].AsDecimal,
                    });
                }

                return salesDetails;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<Sale>();  // Return an empty list if an error occurs
            }
        }
    }
}
