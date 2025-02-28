using MongoDB.Bson;
using MongoDB.Driver;
using SanrooLK.Models;
using System.Collections.ObjectModel;

namespace SanrooLK.Views.AdminOperations.Views
{
    public class SearchCustomer
    {
        private static string connectionString = "mongodb+srv://DesktopClient:6uJegLlg5cjVy5GS@sanroolk.xxwnk.mongodb.net/?retryWrites=true&w=majority&appName=SanrooLK";
        private static string databaseName = "SanrooLKDB";
        private static string collectionName = "Customer";
        private readonly IMongoCollection<BsonDocument> collection;

        public ObservableCollection<Customer> Customers { get; set; }

        public SearchCustomer()
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            collection = database.GetCollection<BsonDocument>(collectionName);
            Customers = new ObservableCollection<Customer>();
        }

        public void SearchCustomers(string searchText)
        {
            // Use regex to search for customer ID or contact (supports case-insensitive search)
            var filter = Builders<BsonDocument>.Filter.Or(
                Builders<BsonDocument>.Filter.Regex("customerID", new BsonRegularExpression(searchText, "i")),
                Builders<BsonDocument>.Filter.Regex("customerContact", new BsonRegularExpression(searchText, "i"))
            );

            var documents = collection.Find(filter).ToList();

            Customers.Clear();
            foreach (var doc in documents)
            {
                Customers.Add(new Customer
                {
                    CustomerID = doc.Contains("customerID") ? doc["customerID"].AsString : "",
                    CustomerName = doc.Contains("customerName") ? doc["customerName"].AsString : "",
                    CustomerNIC = doc.Contains("customerNIC") ? doc["customerNIC"].AsString : "",  // Added this line
                    CustomerContact = doc.Contains("customerContact") ? doc["customerContact"].AsString : ""  // Added this line
                });
            }
        }
    }
}
