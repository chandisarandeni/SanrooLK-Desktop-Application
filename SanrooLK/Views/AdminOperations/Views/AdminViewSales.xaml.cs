using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using SanrooLK.Views.AdminOperations.Controllers; // Correct namespace for LoadInquiries
using SanrooLK.Views.AdminOperations.Models; // Correct namespace for Inquiry

namespace SanrooLK.Views.AdminOperations.Views
{
    public partial class AdminViewSales : UserControl
    {
        // Use Models.Inquiry explicitly to avoid ambiguity
        public ObservableCollection<SanrooLK.Views.AdminOperations.Models.Inquiry> Inquiries { get; set; } = new ObservableCollection<SanrooLK.Views.AdminOperations.Models.Inquiry>();

        public AdminViewSales()
        {
            InitializeComponent();
            this.DataContext = this;  // Ensure data context is set for binding
            LoadInquiriesData();  // Load data when UserControl is initialized
        }

        private async void LoadInquiriesData()
        {
            try
            {
                var inquiries = await LoadInquiries.GetInquiriesAsync();

                Application.Current.Dispatcher.Invoke(() =>
                {
                    Inquiries.Clear();
                    foreach (var inquiry in inquiries)
                    {
                        Inquiries.Add(inquiry);
                    }
                    Debug.WriteLine($"Total Inquiries Loaded: {Inquiries.Count}");
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading inquiries: " + ex.Message);
            }
        }


        // Refresh button click event to reload data
        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            LoadInquiriesData();  // Refresh data when button is clicked
        }

        // Textbox events for Product ID with placeholder functionality
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

        // Event to handle mouse click for selecting options in popups
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

        // Option button click event to set selected options
        private void OptionButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;

            if (OptionPopupCategory.IsOpen)
            {
                SelectedOption.Text = button.Content.ToString();
                OptionPopupCategory.IsOpen = false;
            }
            else if (OptionPopupBrand.IsOpen)
            {
                SelectedOptionBrand.Text = button.Content.ToString();
                OptionPopupBrand.IsOpen = false;
            }
            else if (OptionPopupStockStatus.IsOpen)
            {
                SelectedOptionStockStatus.Text = button.Content.ToString();
                OptionPopupStockStatus.IsOpen = false;
            }
        }
    }
}
