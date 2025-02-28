using MongoDB.Bson;
using MongoDB.Driver;
using SanrooLK.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SanrooLK.Views.AdminOperations.Views
{
    /// <summary>
    /// Interaction logic for AdminViewCustomer.xaml
    /// </summary>
    public partial class AdminViewCustomer : UserControl
    {
        private static string connectionString = "mongodb+srv://DesktopClient:6uJegLlg5cjVy5GS@sanroolk.xxwnk.mongodb.net/?retryWrites=true&w=majority&appName=SanrooLK";
        private static string databaseName = "SanrooLKDB";
        private static string collectionName = "Employee";
        private IMongoCollection<BsonDocument> collection;  // Removed readonly here

        public ObservableCollection<Employee> Employees { get; set; }
        public int EmployeeCount { get; set; } // Add EmployeeCount property

        private SearchEmployee searchEmployee;

        public AdminViewCustomer()
        {
            InitializeComponent();

            txt_employeeID.KeyDown += txt_employeeID_KeyDown;

            searchEmployee = new SearchEmployee();
            Employees = new ObservableCollection<Employee>();

            // Initialize collection inside the constructor
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            collection = database.GetCollection<BsonDocument>(collectionName);

            LoadData();
            DataContext = this; // Bind the data context to this class for data binding
        }

        private void LoadData()
        {
            var sort = Builders<BsonDocument>.Sort.Descending("employeeID");
            var documents = collection.Find(new BsonDocument()).Sort(sort).ToList();

            Employees.Clear(); // Clear existing employees
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

            // Update the EmployeeCount property after loading data
            EmployeeCount = Employees.Count;
            // Notify UI to update binding
            OnPropertyChanged("EmployeeCount");
        }

        // Method to notify UI that a property has changed
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }

        private void txt_employeeID_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txt_employeeID.Text == "Enter Employee ID or NIC to View Details")
            {
                txt_employeeID.Text = "";
                txt_employeeID.Foreground = System.Windows.Media.Brushes.Black;
            }
        }

        private void txt_employeeID_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (txt_employeeID.Text == "Enter Employee ID or NIC to View Details")
            {
                txt_employeeID.Text = "";
                txt_employeeID.Foreground = System.Windows.Media.Brushes.Black;
            }
        }

        private void txt_employeeID_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_employeeID.Text))
            {
                txt_employeeID.Text = "Enter Employee ID or NIC to View Details";
                txt_employeeID.Foreground = System.Windows.Media.Brushes.Gray;
            }
        }

        private void ViewEmployee_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var employee = button?.CommandParameter as Employee;
            if (employee != null)
            {
                MessageBox.Show($"View details for {employee.EmployeeName} ({employee.EmployeeID})");
            }
        }

        private void UpdateEmployee_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var employee = button?.CommandParameter as Employee;
            if (employee != null)
            {
                MessageBox.Show($"Update details for {employee.EmployeeName} ({employee.EmployeeID})");
            }
        }

        private void DeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var employee = button?.CommandParameter as Employee;
            if (employee != null)
            {
                MessageBox.Show($"Delete employee {employee.EmployeeName} ({employee.EmployeeID})");
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var searchText = txt_employeeID.Text;
            searchEmployee.SearchEmployees(searchText); // Search employees by ID or NIC
            Employees.Clear();
            foreach (var emp in searchEmployee.Employees)
            {
                Employees.Add(emp); // Add filtered employees to the collection
            }
        }

        private async void SearchLabel_Click(object sender, RoutedEventArgs e)
        {
            var searchText = txt_employeeID.Text;

            // Check if the search text is empty
            if (string.IsNullOrWhiteSpace(searchText))
            {
                MessageBox.Show("Please Enter Valid Employee ID or NIC", "", MessageBoxButton.OK, MessageBoxImage.Information);
                return; // Exit the method if the input is invalid
            }
            else if (searchText == "Enter Employee ID or NIC to View Details")
            {
                MessageBox.Show("Please Enter Valid Employee ID or NIC", "", MessageBoxButton.OK, MessageBoxImage.Information);
                return; // Exit the method if the input is invalid
            }

            // Perform the search
            searchEmployee.SearchEmployees(searchText);
            Employees.Clear();

            // Add delay for button click feedback
            //await Task.Delay(200);

            // Add the filtered employees to the collection
            foreach (var emp in searchEmployee.Employees)
            {
                Employees.Add(emp);
            }
        }

        private void txt_employeeID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SearchButton_Click(sender, e);
            }
        }
    }
}
