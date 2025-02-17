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

namespace SanrooLK.Views.MainFrames
{
    /// <summary>
    /// Interaction logic for ForgotPassword.xaml
    /// </summary>
    public partial class ForgotPassword : UserControl
    {
        public ForgotPassword()
        {
            InitializeComponent();
        }

        private async void btn_Cancel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;

            if (mainWindow != null)
            {
                // Fade out the current view
                DoubleAnimation fadeOut = new DoubleAnimation(1, 0, TimeSpan.FromSeconds(0.5))
                {
                    EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut }
                };

                // Apply the fade-out animation to the main window
                mainWindow.BeginAnimation(UIElement.OpacityProperty, fadeOut);

                // Wait for the animation to complete
                await Task.Delay(10);

                // Switch to the LoginForm view
                mainWindow.SwitchView(new MainFrames.LoginForm());

                // Reset the opacity for the new view
                mainWindow.Opacity = 0;

                // Set the new view's fade-in animation
                DoubleAnimation fadeIn = new DoubleAnimation(0, 1, TimeSpan.FromSeconds(0.5))
                {
                    EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut }
                };

                // Apply the fade-in animation to the new view
                mainWindow.BeginAnimation(UIElement.OpacityProperty, fadeIn);
            }
        }
    }
}
