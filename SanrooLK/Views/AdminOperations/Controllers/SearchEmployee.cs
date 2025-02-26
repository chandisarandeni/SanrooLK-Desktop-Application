using MongoDB.Bson;
using MongoDB.Driver;
using SanrooLK.Models;
using System.Collections.ObjectModel;

namespace SanrooLK.Views.AdminOperations.Views
{
    public class SearchEmployee
    {
        private static string connectionString = "mongodb+srv://DesktopClient:6uJegLlg5cjVy5GS@sanroolk.xxwnk.mongodb.net/?retryWrites=true&w=majority&appName=SanrooLK";
        private static string databaseName = "SanrooLKDB";
        private static string collectionName = "Employee";
        private readonly IMongoCollection<BsonDocument> collection;

        public ObservableCollection<Employee> Employees { get; set; }

        public SearchEmployee()
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            collection = database.GetCollection<BsonDocument>(collectionName);
            Employees = new ObservableCollection<Employee>();
        }

        public void SearchEmployees(string searchText)
        {
            var filter = Builders<BsonDocument>.Filter.Or(
                Builders<BsonDocument>.Filter.Regex("employeeID", new BsonRegularExpression(searchText, "i")),
                Builders<BsonDocument>.Filter.Regex("employeeNIC", new BsonRegularExpression(searchText, "i"))
            );

            var documents = collection.Find(filter).ToList();

            Employees.Clear();
            foreach (var doc in documents)
            {
                Employees.Add(new Employee
                {
                    EmployeeID = doc.Contains("employeeID") ? doc["employeeID"].AsString : "",
                    EmployeeName = doc.Contains("employeeName") ? doc["employeeName"].AsString : "",
                    NIC = doc.Contains("employeeNIC") ? doc["employeeNIC"].AsString : "",
                    Contact = doc.Contains("employeeContact") ? doc["employeeContact"].AsString : ""
                });
            }
        }
    }
}
