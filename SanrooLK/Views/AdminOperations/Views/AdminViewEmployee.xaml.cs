using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SanrooLK.Views.AdminOperations.Views
{
    public partial class AdminViewEmployee : UserControl
    {
        private static string connectionString = "mongodb+srv://DesktopClient:6uJegLlg5cjVy5GS@sanroolk.xxwnk.mongodb.net/?retryWrites=true&w=majority&appName=SanrooLK";
        private static string databaseName = "SanrooLKDB";
        private static string collectionName = "Employee";
        private readonly IMongoCollection<BsonDocument> collection;

        public ObservableCollection<Employee> Employees { get; set; }

        public AdminViewEmployee()
        {
            InitializeComponent();
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            collection = database.GetCollection<BsonDocument>(collectionName);

            Employees = new ObservableCollection<Employee>();
            LoadData();
            DataContext = this;
        }

        private void LoadData()
        {
            var sort = Builders<BsonDocument>.Sort.Descending("employeeID"); // Change "employeeID" to your desired field
            var documents = collection.Find(new BsonDocument()).Sort(sort).ToList();

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


        private void txt_employeeID_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txt_employeeID.Text == "Enter Employee ID or NIC to View Details")
            {
                txt_employeeID.Text = "";
                txt_employeeID.Foreground = Brushes.Black;
            }
        }

        private void txt_employeeID_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (txt_employeeID.Text == "Enter Employee ID or NIC to View Details")
            {
                txt_employeeID.Text = "";
                txt_employeeID.Foreground = Brushes.Black;
            }
        }

        private void txt_employeeID_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_employeeID.Text))
            {
                txt_employeeID.Text = "Enter Employee ID or NIC to View Details";
                txt_employeeID.Foreground = Brushes.Gray;
            }
        }

        private void ViewEmployee_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var employee = button?.CommandParameter as Employee;
            if (employee != null)
            {
                // Logic to view employee details
                MessageBox.Show($"View details for {employee.EmployeeName} ({employee.EmployeeID})");
            }
        }

        private void UpdateEmployee_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var employee = button?.CommandParameter as Employee;
            if (employee != null)
            {
                // Logic to update employee details
                MessageBox.Show($"Update details for {employee.EmployeeName} ({employee.EmployeeID})");
            }
        }

        private void DeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var employee = button?.CommandParameter as Employee;
            if (employee != null)
            {
                // Logic to delete employee
                MessageBox.Show($"Delete employee {employee.EmployeeName} ({employee.EmployeeID})");
            }
        }


    }

    public class Employee
    {
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string NIC { get; set; }
        public string Contact { get; set; }
    }
}
