// C#
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SanrooLK.Views.AdminOperations.Common
{
    internal class CommonMenuBarController
    {
        public static async void AdminViewDashboard_MouseDown(object sender, MouseButtonEventArgs e)
        {
            await Task.Delay(200); // Add delay for button click feedback
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.SwitchView(new AdminOperations.Views.AdminDashboard());
        }

        public static async void AdminViewEmployee_MouseDown(object sender, MouseButtonEventArgs e)
        {
            await Task.Delay(200); // Add delay for button click feedback
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.SwitchView(new AdminOperations.Views.AdminViewEmployee());
        }

        public static async void AdminViewCustomer_MouseDown(object sender, MouseButtonEventArgs e)
        {
            await Task.Delay(200); // Add delay for button click feedback
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.SwitchView(new AdminOperations.Views.AdminViewCustomer());
        }

        public static async void AdminViewProduct_MouseDown(object sender, MouseButtonEventArgs e)
        {
            await Task.Delay(200); // Add delay for button click feedback
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.SwitchView(new AdminOperations.Views.AdminViewProduct());
        }

        public static async void AdminViewSales_MouseDown(object sender, MouseButtonEventArgs e)
        {
            await Task.Delay(200); // Add delay for button click feedback
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.SwitchView(new AdminOperations.Views.AdminViewSales());
        }

        public static async void AdminViewCustomerService_MouseDown(object sender, MouseButtonEventArgs e)
        {
            await Task.Delay(200); // Add delay for button click feedback
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.SwitchView(new AdminOperations.Views.AdminViewCustomerService());
        }

        public static async void AdminViewMaintenance_MouseDown(object sender, MouseButtonEventArgs e)
        {
            await Task.Delay(200); // Add delay for button click feedback
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.SwitchView(new AdminOperations.Views.AdminViewMaintenance());
        }

        public static async void AdminViewReports_MouseDown(object sender, MouseButtonEventArgs e)
        {
            await Task.Delay(200); // Add delay for button click feedback
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.SwitchView(new AdminOperations.Views.AdminViewReports());
        }

        public static async void AdminViewSettings_MouseDown(object sender, MouseButtonEventArgs e)
        {
            await Task.Delay(200); // Add delay for button click feedback
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.SwitchView(new AdminOperations.Views.AdminViewSettings());
        }
    }
}
