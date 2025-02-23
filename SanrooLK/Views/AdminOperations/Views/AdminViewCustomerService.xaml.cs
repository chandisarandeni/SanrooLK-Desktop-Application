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
    /// Interaction logic for AdminViewCustomerService.xaml
    /// </summary>
    public partial class AdminViewCustomerService : UserControl
    {
        public AdminViewCustomerService()
        {
            InitializeComponent();
        }

        private void txt_customerID_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txt_customerID.Text == "Enter Customer ID or NIC to View Details")
            {
                txt_customerID.Text = "";
                txt_customerID.Foreground = Brushes.Black;
            }
        }

        private void txt_customerID_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (txt_customerID.Text == "Enter Customer ID or NIC to View Details")
            {
                txt_customerID.Text = "";
                txt_customerID.Foreground = Brushes.Black;
            }
        }

        private void txt_customerID_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_customerID.Text))
            {
                txt_customerID.Text = "Enter Employee ID or NIC to View Details";
                txt_customerID.Foreground = Brushes.Gray;
            }
        }
    }
}
