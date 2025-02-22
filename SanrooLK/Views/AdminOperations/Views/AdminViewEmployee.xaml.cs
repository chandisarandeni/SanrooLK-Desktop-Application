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
    /// Interaction logic for AdminViewEmployee.xaml
    /// </summary>
    public partial class AdminViewEmployee : UserControl
    {
        public AdminViewEmployee()
        {
            InitializeComponent();
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
    }
}
