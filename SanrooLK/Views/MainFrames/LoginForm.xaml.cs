using SanrooLK.Views.AdminOperations.Common;
using SanrooLK.Views.MainFrames.Controllers;
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
    /// Interaction logic for LoginForm.xaml
    /// </summary>
    public partial class LoginForm : UserControl
    {
        public LoginForm()
        {
            InitializeComponent();

            // Wire up the login button event
            this.btn_Login.MouseDown += UserLogin.Login_MouseDown;
        }

        //Forgot Password
        // C#
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

                // Apply fade-out animation to the current view
                mainWindow.BeginAnimation(UIElement.OpacityProperty, fadeOut);

                // Wait for the animation to finish
                await Task.Delay(10);

                // Switch to the ForgotPassword view
                mainWindow.SwitchView(new Views.MainFrames.ForgotPassword());

                // Set the new view's opacity to 0 initially
                mainWindow.Opacity = 0;

                // Fade in the new view
                DoubleAnimation fadeIn = new DoubleAnimation(0, 1, TimeSpan.FromSeconds(0.5))
                {
                    EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut }
                };

                // Apply fade-in animation to the new view
                mainWindow.BeginAnimation(UIElement.OpacityProperty, fadeIn);
            }
        }


    }
}
