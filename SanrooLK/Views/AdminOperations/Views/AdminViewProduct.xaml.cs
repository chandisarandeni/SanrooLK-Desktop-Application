using MongoDB.Bson;
using MongoDB.Driver;
using SanrooLK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace SanrooLK.Views.AdminOperations.Views
{
    public partial class AdminViewProduct : UserControl
    {
        private static string connectionString = "mongodb+srv://DesktopClient:6uJegLlg5cjVy5GS@sanroolk.xxwnk.mongodb.net/?retryWrites=true&w=majority&appName=SanrooLK";
        private static string databaseName = "SanrooLKDB";
        private static string collectionName = "Product";
        private IMongoCollection<BsonDocument> collection;

        public ObservableCollection<Product> Products { get; set; }
        public int ProductCount { get; set; }

        private string selectedCategory;
        private string selectedBrand;
        private string selectedStockStatus;

        public AdminViewProduct()
        {
            InitializeComponent();

            txt_productID.KeyDown += txt_customerID_KeyDown;

            txt_productID.GotFocus += txt_productID_GotFocus;
            txt_productID.LostFocus += txt_productID_LostFocus;
            txt_productID.PreviewTextInput += txt_productID_PreviewTextInput;

            Products = new ObservableCollection<Product>();
            selectedCategory = "All Categories";
            selectedBrand = "All Brands";
            selectedStockStatus = "All Stock Status";

            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            collection = database.GetCollection<BsonDocument>(collectionName);

            LoadData();
            DataContext = this;
        }

        private async void LoadData()
        {
            var filter = Builders<BsonDocument>.Filter.Empty;

            // Apply filters based on selected category, brand, and available status
            if (selectedCategory != "All Categories")
                filter &= Builders<BsonDocument>.Filter.Eq("productCategory", selectedCategory);

            if (selectedBrand != "All Brands")
                filter &= Builders<BsonDocument>.Filter.Eq("productBrand", selectedBrand);

            if (selectedStockStatus != "All Stock Status")
                filter &= Builders<BsonDocument>.Filter.Eq("productStockStatus", selectedStockStatus);

            // Add filter for IsAvailable status
            if (selectedStockStatus == "Available")
                filter &= Builders<BsonDocument>.Filter.Eq("isAvailable", true);
            else if (selectedStockStatus == "Not Available")
                filter &= Builders<BsonDocument>.Filter.Eq("isAvailable", false);

            // Add filter for product ID search
            if (!string.IsNullOrEmpty(txt_productID.Text) && txt_productID.Text != "Enter Product ID to View Details")
            {
                filter &= Builders<BsonDocument>.Filter.Eq("productID", txt_productID.Text);
            }

            // Define the projection to include only necessary fields
            var projection = Builders<BsonDocument>.Projection.Include("productID")
                                                               .Include("productName")
                                                               .Include("productCategory")
                                                               .Include("productBrand");

            var documents = await collection.Find(filter).Project(projection).ToListAsync();

            Products.Clear();
            foreach (var doc in documents)
            {
                Products.Add(new Product
                {
                    ProductID = doc.Contains("productID") ? doc["productID"].AsString : "",
                    ProductName = doc.Contains("productName") ? doc["productName"].AsString : "",
                    ProductCategory = doc.Contains("productCategory") ? doc["productCategory"].AsString : "",
                    ProductBrand = doc.Contains("productBrand") ? doc["productBrand"].AsString : "",
                });
            }

            ProductCount = Products.Count;
            OnPropertyChanged("ProductCount");
        }

        private void txt_productID_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txt_productID.Text == "Enter Product ID to View Details")
            {
                txt_productID.Text = "";
                txt_productID.Foreground = Brushes.Black;
            }
        }

        private void txt_productID_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (txt_productID.Text == "Enter Product ID to View Details")
            {
                txt_productID.Text = "";
                txt_productID.Foreground = Brushes.Black;
            }
        }

        private void txt_productID_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_productID.Text))
            {
                txt_productID.Text = "Enter Product ID to View Details";
                txt_productID.Foreground = Brushes.Gray;
            }
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender == SelectedOption)
            {
                OptionPopupCategory.IsOpen = !OptionPopupCategory.IsOpen;
            }
            else if (sender == SelectedOptionBrand)
            {
                OptionPopupBrand.IsOpen = !OptionPopupBrand.IsOpen;
            }
            else if (sender == SelectedOptionStockStatus)
            {
                OptionPopupStockStatus.IsOpen = !OptionPopupStockStatus.IsOpen;
            }
        }

        private void OptionButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;

            if (OptionPopupCategory.IsOpen)
            {
                SelectedOption.Text = button.Content.ToString();
                selectedCategory = button.Content.ToString();
                OptionPopupCategory.IsOpen = false;
            }
            else if (OptionPopupBrand.IsOpen)
            {
                SelectedOptionBrand.Text = button.Content.ToString();
                selectedBrand = button.Content.ToString();
                OptionPopupBrand.IsOpen = false;
            }
            else if (OptionPopupStockStatus.IsOpen)
            {
                SelectedOptionStockStatus.Text = button.Content.ToString();
                selectedStockStatus = button.Content.ToString();
                OptionPopupStockStatus.IsOpen = false;
            }

            LoadData(); // Refresh data based on selected filters
        }

        private void ViewProduct_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var product = button?.CommandParameter as Product;
            if (product != null)
            {
                MessageBox.Show($"View details for {product.ProductName} ({product.ProductID})");
            }
        }

        private void UpdateProduct_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var product = button?.CommandParameter as Product;
            if (product != null)
            {
                MessageBox.Show($"Update details for {product.ProductName} ({product.ProductID})");
            }
        }

        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var product = button?.CommandParameter as Product;
            if (product != null)
            {
                MessageBox.Show($"Delete product {product.ProductName} ({product.ProductID})");
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            LoadData(); // Refresh data based on the search text and filters
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
        private void btn_Search_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            LoadData(); // Trigger search based on entered text
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
