using System;
using System.Collections.Generic;
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
    /// Interaction logic for AdminViewSales.xaml
    /// </summary>
    public partial class AdminViewSales : UserControl
    {
        public AdminViewSales()
        {
            InitializeComponent();
        }


        private void txt_productID_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txt_productID.Text == "Enter Product ID to View Details")
            {
                txt_productID.Text = "";
                txt_productID.Foreground = Brushes.Black;
            }
        }

        private void txt_productID_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
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
                txt_productID.Text = "Enter Employee ID or NIC to View Details";
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

        private void MenuBarSales_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
