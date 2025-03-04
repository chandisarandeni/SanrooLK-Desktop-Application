using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Threading.Tasks;
using SanrooLK.Views.AdminOperations.Controllers;
using SanrooLK.Views.AdminOperations.Views;

namespace SanrooLK.Views.AdminOperations.Views
{
    public partial class AdminDashboard : UserControl, INotifyPropertyChanged
    {
        private string _currentTime;
        private int _employeeCount;
        private int _customerCount;
        private int _productCount;
        private ObservableCollection<Checkout> _recentCheckouts;

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

        public int ProductCount
        {
            get { return _productCount; }
            set
            {
                if (_productCount != value)
                {
                    _productCount = value;
                    OnPropertyChanged(nameof(ProductCount));
                }
            }
        }

        public ObservableCollection<Checkout> RecentCheckouts
        {
            get { return _recentCheckouts; }
            set
            {
                _recentCheckouts = value;
                OnPropertyChanged(nameof(RecentCheckouts));
            }
        }

        public AdminDashboard()
        {
            InitializeComponent();
            this.DataContext = this;

            CurrentDate = DateTime.Now.ToString("dddd, MMMM dd, yyyy");
            CurrentTime = DateTime.Now.ToString("HH:mm:ss");

            // Timer to update the current time every second
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (s, e) => { CurrentTime = DateTime.Now.ToString("HH:mm:ss"); };
            timer.Start();

            // Initialize the ObservableCollection for RecentCheckouts
            RecentCheckouts = new ObservableCollection<Checkout>();

            // Asynchronously load data
            LoadDataAsync();
        }

        private async void LoadDataAsync()
        {
            // Fetch counts asynchronously
            EmployeeCount = await LoadEmployeeCount.GetEmployeeCount();
            CustomerCount = await LoadCustomerCount.GetCustomerCount();
            ProductCount = await LoadProductCount.GetProductCount();

            // Load checkout data
            await LoadCheckoutsAsync();
        }

        private async Task LoadCheckoutsAsync()
        {
            var checkoutData = await LoadCheckoutData.GetCheckoutDetails();

            if (checkoutData == null || checkoutData.Count == 0)
            {
                // Handle empty data case (optional logging)
                return;
            }

            // Clear the existing checkout data
            RecentCheckouts.Clear();

            // Add new checkout data to the ObservableCollection
            foreach (var checkout in checkoutData)
            {
                // Map from Controllers.Checkout to Views.Checkout
                RecentCheckouts.Add(new Checkout
                {
                    CheckoutID = checkout.CheckoutID,
                    CheckoutDate = checkout.CheckoutDate,  // Already formatted in GetCheckoutDetails
                    UnitTotal = checkout.UnitTotal,
                    DiscountPrice = checkout.DiscountPrice,
                    FinalPrice = checkout.FinalPrice,
                });
            }
        }

        // PropertyChanged event for binding updates
        public event PropertyChangedEventHandler PropertyChanged;

        // Method to trigger PropertyChanged event
        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
