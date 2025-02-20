using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using System.ComponentModel;

namespace SanrooLK.Views.AdminOperations.Common
{
    public partial class UpMenuEmployee : UserControl, INotifyPropertyChanged
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

        public UpMenuEmployee()
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
