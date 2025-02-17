using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SanrooLK.Views.AdminOperations.Common
{
    internal class CommonMenuBarController
    {
        public static void AdminViewDashboard_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.SwitchView(new AdminOperations.Views.AdminDashboard());
        }
        public static void AdminViewEmployee_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.SwitchView(new AdminOperations.Views.AdminViewEmployee());
        }

        public static void AdminViewCustomer_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.SwitchView(new AdminOperations.Views.AdminViewCustomer());
        }

        public static void AdminViewProduct_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.SwitchView(new AdminOperations.Views.AdminViewProduct());
        }

        public static void AdminViewSales_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.SwitchView(new AdminOperations.Views.AdminViewSales());
        }

        public static void AdminViewCustomerService_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.SwitchView(new AdminOperations.Views.AdminViewCustomerService());
        }

        public static void AdminViewMaintenance_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.SwitchView(new AdminOperations.Views.AdminViewMaintenance());
        }

        public static void AdminViewReports_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.SwitchView(new AdminOperations.Views.AdminViewReports());
        }

        public static void AdminViewSettings_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.SwitchView(new AdminOperations.Views.AdminViewSettings());
        }
    }
}
