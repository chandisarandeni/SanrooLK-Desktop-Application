using MongoDB.Bson;
using MongoDB.Driver;
using SanrooLK.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SanrooLK.Views.AdminOperations.Views
{
    public class SearchProduct
    {
        private static string connectionString = "mongodb+srv://DesktopClient:6uJegLlg5cjVy5GS@sanroolk.xxwnk.mongodb.net/?retryWrites=true&w=majority&appName=SanrooLK";
        private static string databaseName = "SanrooLKDB";
        private static string collectionName = "Product";
        private readonly IMongoCollection<BsonDocument> collection;

        public ObservableCollection<Product> Products { get; set; }

        public SearchProduct()
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            collection = database.GetCollection<BsonDocument>(collectionName);
            Products = new ObservableCollection<Product>();
        }

        public async Task SearchProductsAsync(string searchText)
        {
            var filter = Builders<BsonDocument>.Filter.Or(
                Builders<BsonDocument>.Filter.Regex("productID", new BsonRegularExpression(searchText, "i")),
                Builders<BsonDocument>.Filter.Regex("productName", new BsonRegularExpression(searchText, "i")),
                Builders<BsonDocument>.Filter.Regex("productCategory", new BsonRegularExpression(searchText, "i")),
                Builders<BsonDocument>.Filter.Regex("productBrand", new BsonRegularExpression(searchText, "i"))
            );

            var documents = await collection.Find(filter).ToListAsync();

            Products.Clear();
            foreach (var doc in documents)
            {
                Products.Add(new Product
                {
                    ProductID = doc.Contains("productID") ? doc["productID"].AsString : "",
                    ProductName = doc.Contains("productName") ? doc["productName"].AsString : "",
                    ProductCategory = doc.Contains("productCategory") ? doc["productCategory"].AsString : "",
                    ProductBrand = doc.Contains("productBrand") ? doc["productBrand"].AsString : ""
                });
            }
        }
    }
}
