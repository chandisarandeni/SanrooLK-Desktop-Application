using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using SanrooLK.Views.MainFrames;

namespace SanrooLK
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e) {
            showLoginForm();
        }

        private void showLoginForm() { 
            var LoginForm = new LoginForm();
            this.Content = LoginForm;
        }

        public void SwitchView(UserControl newView) {
            if (this.Content is UserControl oldView && oldView is IDisposable disposable) { 
                disposable.Dispose();
            }
            this.Content = null;
            this.Content = newView;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e) {
            if (e.Key == Key.F11)
            {
                // Toggle Fullscreen
                this.WindowState = this.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
            }
            else if (e.Key == Key.PageDown) { 
                Application.Current.Shutdown();
            }

        }
    }
}