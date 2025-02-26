using System;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Threading.Tasks;
using SanrooLK.Views.AdminOperations.Controllers;

namespace SanrooLK.Views.AdminOperations.Views
{
    public partial class AdminDashboard : UserControl, INotifyPropertyChanged
    {
        private string _currentTime;
        private int _employeeCount;
        private int _customerCount;

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

        public int EmployeeCount
        {
            get { return _employeeCount; }
            set
            {
                if (_employeeCount != value)
                {
                    _employeeCount = value;
                    OnPropertyChanged(nameof(EmployeeCount));
                }
            }
        }

        public int CustomerCount
        {
            get { return _customerCount; }
            set
            {
                if (_customerCount != value)
                {
                    _customerCount = value;
                    OnPropertyChanged(nameof(CustomerCount));
                }
            }
        }

        public AdminDashboard()
        {
            InitializeComponent();
            this.DataContext = this;

            CurrentDate = DateTime.Now.ToString("dddd, MMMM dd, yyyy");
            CurrentTime = DateTime.Now.ToString("HH:mm:ss");

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (s, e) => { CurrentTime = DateTime.Now.ToString("HH:mm:ss"); };
            timer.Start();

            LoadCountsAsync();
        }

        private async void LoadCountsAsync()
        {
            EmployeeCount = await LoadEmployeeCount.GetEmployeeCount();
            CustomerCount = await LoadCustomerCount.GetCustomerCount();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
