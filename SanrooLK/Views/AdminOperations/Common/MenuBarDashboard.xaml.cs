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

using SanrooLK.Views.AdminOperations.Views;
using SanrooLK.Views.MainFrames;

namespace SanrooLK.Views.AdminOperations.Common
{
    /// <summary>
    /// Interaction logic for MenuBarDashboard.xaml
    /// </summary>
    public partial class MenuBarDashboard : UserControl
    {
        public MenuBarDashboard()
        {
            InitializeComponent();
        }

        private async void btn_Logout_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;

            if (mainWindow != null)
            {
                // Create ScaleTransform for zoom effect
                var transform = new ScaleTransform();
                mainWindow.RenderTransform = transform;

                // Set the center of scaling to the middle of the window
                transform.CenterX = mainWindow.ActualWidth / 2;
                transform.CenterY = mainWindow.ActualHeight / 2;

                // Zoom out the current view (Scale to 0)
                DoubleAnimation scaleOut = new DoubleAnimation(1, 0, TimeSpan.FromSeconds(0.5))
                {
                    EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
                };

                // Fade out the current view
                DoubleAnimation fadeOut = new DoubleAnimation(1, 0, TimeSpan.FromSeconds(0.5))
                {
                    EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut }
                };

                // Apply animations to the current view
                transform.BeginAnimation(ScaleTransform.ScaleXProperty, scaleOut);
                transform.BeginAnimation(ScaleTransform.ScaleYProperty, scaleOut);
                mainWindow.BeginAnimation(UIElement.OpacityProperty, fadeOut);

                // Wait for animations to finish
                await Task.Delay(500);

                // Switch to the LoginForm view
                mainWindow.SwitchView(new MainFrames.LoginForm());

                // Reset transform for the new view (Zoomed out to center)
                transform.ScaleX = 0;
                transform.ScaleY = 0;
                transform.CenterX = mainWindow.ActualWidth / 2;
                transform.CenterY = mainWindow.ActualHeight / 2;
                mainWindow.Opacity = 0;

                // Set the new view's fade-in and zoom-in animations
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


        private void adminViewEmployee_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.SwitchView(new AdminOperations.Views.AdminViewEmployee());
        }

        private void AdminViewCustomer_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.SwitchView(new AdminOperations.Views.AdminViewCustomer());
        }
    }
}
