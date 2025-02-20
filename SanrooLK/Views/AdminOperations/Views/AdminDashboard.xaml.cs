using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace SanrooLK.Views.AdminOperations.Views
{
    public partial class AdminDashboard : UserControl, INotifyPropertyChanged
    {
        private string _currentTime;
        public string CurrentDate { get; set; }

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

        public AdminDashboard()
        {
            InitializeComponent();
            this.DataContext = this;

            // Set current date and time
            CurrentDate = DateTime.Now.ToString("dddd, MMMM dd, yyyy");
            CurrentTime = DateTime.Now.ToString("HH:mm:ss");

            // Timer to update the time every second
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (s, e) =>
            {
                CurrentTime = DateTime.Now.ToString("HH:mm:ss");
            };
            timer.Start();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
