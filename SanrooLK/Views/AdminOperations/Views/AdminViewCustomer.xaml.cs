using MongoDB.Bson;
using MongoDB.Driver;
using SanrooLK.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SanrooLK.Views.AdminOperations.Views
{
    public partial class AdminViewCustomer : UserControl
    {
        private static string connectionString = "mongodb+srv://DesktopClient:6uJegLlg5cjVy5GS@sanroolk.xxwnk.mongodb.net/?retryWrites=true&w=majority&appName=SanrooLK";
        private static string databaseName = "SanrooLKDB";
        private static string collectionName = "Customer";
        private IMongoCollection<BsonDocument> collection;

        public ObservableCollection<Customer> Customers { get; set; }
        public int CustomerCount { get; set; }

        private SearchCustomer searchCustomer;

        public AdminViewCustomer()
        {
            InitializeComponent();

            txt_customerID.KeyDown += txt_customerID_KeyDown;

            searchCustomer = new SearchCustomer();
            Customers = new ObservableCollection<Customer>();

            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            collection = database.GetCollection<BsonDocument>(collectionName);

            LoadData();
            DataContext = this;
        }

        private async void LoadData()
        {
            var sort = Builders<BsonDocument>.Sort.Descending("customerID");
            var documents = await collection.Find(new BsonDocument()).Sort(sort).ToListAsync();

            Customers.Clear();
            foreach (var doc in documents)
            {
                Customers.Add(new Customer
                {
                    CustomerID = doc.Contains("customerID") ? doc["customerID"].AsString : "",
                    CustomerName = doc.Contains("customerName") ? doc["customerName"].AsString : "",
                    CustomerNIC = doc.Contains("customerNIC") ? doc["customerNIC"].AsString : "",
                    CustomerContact = doc.Contains("customerContact") ? doc["customerContact"].AsString : ""
                });
            }

            CustomerCount = Customers.Count;
            OnPropertyChanged("CustomerCount");
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }

        private void txt_customerID_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txt_customerID.Text == "Enter Customer ID or Contact to View Details")
            {
                txt_customerID.Text = "";
                txt_customerID.Foreground = System.Windows.Media.Brushes.Black;
            }
        }

        private void txt_customerID_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_customerID.Text))
            {
                txt_customerID.Text = "Enter Customer ID or Contact to View Details";
                txt_customerID.Foreground = System.Windows.Media.Brushes.Gray;
            }
        }

        private void ViewCustomer_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var customer = button?.CommandParameter as Customer;
            if (customer != null)
            {
                MessageBox.Show($"View details for {customer.CustomerName} ({customer.CustomerID})");
            }
        }

        private void UpdateCustomer_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var customer = button?.CommandParameter as Customer;
            if (customer != null)
            {
                MessageBox.Show($"Update details for {customer.CustomerName} ({customer.CustomerID})");
            }
        }

        private void DeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var customer = button?.CommandParameter as Customer;
            if (customer != null)
            {
                MessageBox.Show($"Delete customer {customer.CustomerName} ({customer.CustomerID})");
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var searchText = txt_customerID.Text;
            searchCustomer.SearchCustomers(searchText);
            Customers.Clear();
            foreach (var cust in searchCustomer.Customers)
            {
                Customers.Add(cust);
            }
        }

        private async void SearchLabel_Click(object sender, RoutedEventArgs e)
        {
            var searchText = txt_customerID.Text;

            // Check if the search text is empty
            if (string.IsNullOrWhiteSpace(searchText))
            {
                MessageBox.Show("Please Enter Valid Customer ID or NIC", "", MessageBoxButton.OK, MessageBoxImage.Information);
                return; // Exit the method if the input is invalid
            }
            else if (searchText == "Enter Customer ID or NIC to View Details")
            {
                MessageBox.Show("Please Enter Valid Customer ID or NIC", "", MessageBoxButton.OK, MessageBoxImage.Information);
                return; // Exit the method if the input is invalid
            }

            // Perform the search
            searchCustomer.SearchCustomers(searchText);
            Customers.Clear();

            // Add the filtered customers to the collection
            foreach (var customer in searchCustomer.Customers)
            {
                Customers.Add(customer);
            }
        }

        private void txt_customerID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SearchButton_Click(sender, e);
            }
        }
    }
}
