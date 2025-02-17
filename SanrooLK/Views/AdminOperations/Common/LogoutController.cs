// C#
using SanrooLK.Views.MainFrames;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace SanrooLK.Views.AdminOperations.Common
{
    internal class LogoutController
    {
        public static async void HandleLogout(object sender, MouseButtonEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to log out?", "Confirm Logout", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                var mainWindow = (MainWindow)Application.Current.MainWindow;

                if (mainWindow != null)
                {
                    // Introduce a short delay for button click feedback
                    await Task.Delay(300); // 100 milliseconds delay

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
                    mainWindow.SwitchView(new LoginForm());

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
        }
    }
}
