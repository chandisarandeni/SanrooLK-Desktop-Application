using MongoDB.Driver;
using SanrooLK.Views.AdminOperations.Views;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Media;
using SanrooLK.Views.AdminOperations.Common;
using SanrooLK.Models;

namespace SanrooLK.Views.MainFrames
{
    public static class SessionData
    {
        public static string AdminID { get; set; }
        public static string AdminUsername { get; set; }
    }

    public partial class LoginForm : UserControl
    {
        private static string connectionString = "mongodb+srv://DesktopClient:6uJegLlg5cjVy5GS@sanroolk.xxwnk.mongodb.net/?retryWrites=true&w=majority&appName=SanrooLK";
        private static string databaseName = "SanrooLKDB";
        private static string collectionName = "SystemAdmin";

        public LoginForm()
        {
            InitializeComponent();
            this.btn_ForgotPassword.MouseDown += btn_ForgotPassword_MouseDown;
            this.btn_Login.MouseDown += btn_Login_MouseDown;
            this.txt_Password.KeyDown += txt_Password_KeyDown;
            this.txt_Username.Focus();
        }

        private void txt_Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btn_Login_MouseDown(sender, new MouseButtonEventArgs(Mouse.PrimaryDevice, 0, MouseButton.Left));
            }
        }

        public string Username => txt_Username.Text;
        public string Password => txt_Password.Password;

        private async void btn_ForgotPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            if (mainWindow != null)
            {
                DoubleAnimation fadeOut = new DoubleAnimation(1, 0, TimeSpan.FromSeconds(0.3))
                {
                    EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut }
                };
                mainWindow.BeginAnimation(UIElement.OpacityProperty, fadeOut);
                await Task.Delay(150);
                mainWindow.SwitchView(new Views.MainFrames.ForgotPassword());
                mainWindow.Opacity = 0;
                DoubleAnimation fadeIn = new DoubleAnimation(0, 1, TimeSpan.FromSeconds(0.3))
                {
                    EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut }
                };
                mainWindow.BeginAnimation(UIElement.OpacityProperty, fadeIn);
            }
        }

        private async void btn_Login_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string username = Username;
            string password = Password;

            if (AuthenticateUser(username, password))
            {
                var mainWindow = (MainWindow)Application.Current.MainWindow;
                if (mainWindow != null)
                {
                    var transform = new ScaleTransform();
                    mainWindow.RenderTransform = transform;
                    transform.CenterX = mainWindow.ActualWidth / 2;
                    transform.CenterY = mainWindow.ActualHeight / 2;

                    DoubleAnimation scaleOut = new DoubleAnimation(1, 0, TimeSpan.FromSeconds(0.5))
                    {
                        EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
                    };
                    DoubleAnimation fadeOut = new DoubleAnimation(1, 0, TimeSpan.FromSeconds(0.5))
                    {
                        EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut }
                    };
                    transform.BeginAnimation(ScaleTransform.ScaleXProperty, scaleOut);
                    transform.BeginAnimation(ScaleTransform.ScaleYProperty, scaleOut);
                    mainWindow.BeginAnimation(UIElement.OpacityProperty, fadeOut);
                    await Task.Delay(500);

                    mainWindow.SwitchView(new AdminDashboard());
                    transform.ScaleX = 0;
                    transform.ScaleY = 0;
                    mainWindow.Opacity = 0;

                    DoubleAnimation scaleIn = new DoubleAnimation(0, 1, TimeSpan.FromSeconds(0.5))
                    {
                        EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
                    };
                    DoubleAnimation fadeIn = new DoubleAnimation(0, 1, TimeSpan.FromSeconds(0.5))
                    {
                        EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut }
                    };
                    transform.BeginAnimation(ScaleTransform.ScaleXProperty, scaleIn);
                    transform.BeginAnimation(ScaleTransform.ScaleYProperty, scaleIn);
                    mainWindow.BeginAnimation(UIElement.OpacityProperty, fadeIn);
                }
            }
            else
            {
                MessageBox.Show("Invalid Username or Password", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                txt_Username.Text = "";
                txt_Password.Password = "";
                txt_Username.Focus();
            }
        }

        private static bool AuthenticateUser(string username, string password)
        {
            try
            {
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase(databaseName);
                var collection = database.GetCollection<SystemAdmin>(collectionName);
                var filter = Builders<SystemAdmin>.Filter.Eq(admin => admin.AdminUsername, username) &
                             Builders<SystemAdmin>.Filter.Eq(admin => admin.AdminPassword, password);
                var result = collection.Find(filter).FirstOrDefault();

                if (result != null)
                {
                    SessionData.AdminID = result.AdminID;
                    SessionData.AdminUsername = result.AdminUsername;
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred during authentication: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
    }
}
