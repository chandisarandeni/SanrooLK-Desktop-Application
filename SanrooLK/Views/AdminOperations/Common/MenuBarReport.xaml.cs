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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SanrooLK.Views.AdminOperations.Common
{
    /// <summary>
    /// Interaction logic for MenuBarReport.xaml
    /// </summary>
    public partial class MenuBarReport : UserControl
    {
        public MenuBarReport()
        {
            InitializeComponent();

            // Assuming you have buttons or controls that trigger these events
            this.btn_adminDashboard.MouseDown += CommonMenuBarController.AdminViewDashboard_MouseDown;
            this.btn_adminViewEmployee.MouseDown += CommonMenuBarController.AdminViewEmployee_MouseDown;
            this.btn_adminViewCustomer.MouseDown += CommonMenuBarController.AdminViewCustomer_MouseDown;
            this.btn_adminViewProduct.MouseDown += CommonMenuBarController.AdminViewProduct_MouseDown;
            this.btn_adminViewSales.MouseDown += CommonMenuBarController.AdminViewSales_MouseDown;
            this.btn_adminViewCustomerService.MouseDown += CommonMenuBarController.AdminViewCustomerService_MouseDown;
            this.btn_adminViewMaintenance.MouseDown += CommonMenuBarController.AdminViewMaintenance_MouseDown;
            this.btn_adminViewReports.MouseDown += CommonMenuBarController.AdminViewReports_MouseDown;
            this.btn_adminViewSettings.MouseDown += CommonMenuBarController.AdminViewSettings_MouseDown;

            // Wire up the logout button event
            this.btn_Logout.MouseDown += LogoutController.HandleLogout;
        }
    }
}
