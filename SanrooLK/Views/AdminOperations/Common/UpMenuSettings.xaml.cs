using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SanrooLK.Views.AdminOperations.Common
{
    /// <summary>
    /// Interaction logic for UpMenuSettings.xaml
    /// </summary>
    public partial class UpMenuSettings : UserControl, INotifyPropertyChanged
    {
        // Property to hold current time
        private string _currentTime;
        public string CurrentTime
        {
            get { return _currentTime; }
            set
            {
                if (_currentTime != value)
                {
                    _currentTime = value;
                    OnPropertyChanged(nameof(CurrentTime));
                }
            }
        }

        public UpMenuSettings()
        {
            InitializeComponent();

            // Set the initial time
            CurrentTime = DateTime.Now.ToString("HH:mm:ss");
            this.DataContext = this; // Set DataContext to allow binding

            // Set up a timer to update the time every second
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (s, e) =>
            {
                // Update current time every second
                CurrentTime = DateTime.Now.ToString("HH:mm:ss");
            };
            timer.Start();
        }

        // Event to notify that a property has changed
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
