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
    public partial class LoginForm : UserControl
    {
        // MongoDB connection string and database settings
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

        // Properties to get the username and password
        public string Username => txt_Username.Text;
        public string Password => txt_Password.Password;

        // Forgot Password logic
        private async void btn_ForgotPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;

            if (mainWindow != null)
            {
                // Fade out the current view
                DoubleAnimation fadeOut = new DoubleAnimation(1, 0, TimeSpan.FromSeconds(0.5))
                {
                    EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut }
                };
                mainWindow.BeginAnimation(UIElement.OpacityProperty, fadeOut);

                await Task.Delay(500); // Allow enough time for the animation to complete

                // Switch to ForgotPassword view
                mainWindow.SwitchView(new Views.MainFrames.ForgotPassword());

                // Set the new view's opacity to 0 initially
                mainWindow.Opacity = 0;

                // Fade in the new view
                DoubleAnimation fadeIn = new DoubleAnimation(0, 1, TimeSpan.FromSeconds(0.5))
                {
                    EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut }
                };

                mainWindow.BeginAnimation(UIElement.OpacityProperty, fadeIn);
            }
        }

        // Login button click logic
        private async void btn_Login_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string username = Username;  // Get the username from the textbox
            string password = Password;  // Get the password from the PasswordBox

            // Authenticate user
            if (AuthenticateUser(username, password))
            {
                var mainWindow = (MainWindow)Application.Current.MainWindow;
                if (mainWindow != null)
                {
                    // Set up scaling transform and apply it to the main window
                    var transform = new ScaleTransform();
                    mainWindow.RenderTransform = transform;

                    // Set the center of scaling to the middle of the window
                    transform.CenterX = mainWindow.ActualWidth / 2;
                    transform.CenterY = mainWindow.ActualHeight / 2;

                    // Zoom out and fade out animations
                    DoubleAnimation scaleOut = new DoubleAnimation(1, 0, TimeSpan.FromSeconds(0.5))
                    {
                        EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
                    };
                    DoubleAnimation fadeOut = new DoubleAnimation(1, 0, TimeSpan.FromSeconds(0.5))
                    {
                        EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut }
                    };

                    // Apply animations
                    transform.BeginAnimation(ScaleTransform.ScaleXProperty, scaleOut);
                    transform.BeginAnimation(ScaleTransform.ScaleYProperty, scaleOut);
                    mainWindow.BeginAnimation(UIElement.OpacityProperty, fadeOut);

                    // Wait for animations to finish
                    await Task.Delay(500);

                    // Switch to the AdminDashboard view
                    mainWindow.SwitchView(new AdminDashboard());

                    // Reset the transform for the new view (zoomed out to center)
                    transform.ScaleX = 0;
                    transform.ScaleY = 0;
                    transform.CenterX = mainWindow.ActualWidth / 2;
                    transform.CenterY = mainWindow.ActualHeight / 2;
                    mainWindow.Opacity = 0;

                    // Set up fade-in and zoom-in animations
                    DoubleAnimation scaleIn = new DoubleAnimation(0, 1, TimeSpan.FromSeconds(0.5))
                    {
                        EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
                    };
                    DoubleAnimation fadeIn = new DoubleAnimation(0, 1, TimeSpan.FromSeconds(0.5))
                    {
                        EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut }
                    };

                    // Apply animations to the new view
                    transform.BeginAnimation(ScaleTransform.ScaleXProperty, scaleIn);
                    transform.BeginAnimation(ScaleTransform.ScaleYProperty, scaleIn);
                    mainWindow.BeginAnimation(UIElement.OpacityProperty, fadeIn);
                }
            }
            else
            {
                MessageBox.Show("Invalid Username or Password", "", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


        // Method to authenticate the user using MongoDB
        private static bool AuthenticateUser(string username, string password)
        {
            try
            {
                // Create MongoDB client and get the database and collection
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase(databaseName);
                var collection = database.GetCollection<SystemAdmin>(collectionName);

                // Query the collection for a matching username and password
                var filter = Builders<SystemAdmin>.Filter.Eq(admin => admin.AdminUsername, username) &
                             Builders<SystemAdmin>.Filter.Eq(admin => admin.AdminPassword, password);
                var result = collection.Find(filter).FirstOrDefault();

                // If the result is not null, login is successful
                return result != null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred during authentication: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
    }
}
