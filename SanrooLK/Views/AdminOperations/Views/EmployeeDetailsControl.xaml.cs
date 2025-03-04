using System.Windows;
using System.Windows.Controls;

namespace SanrooLK.Views.AdminOperations.Views
{
    public partial class EmployeeDetailsControl : UserControl
    {
        public Employee Employee { get; set; }

        public EmployeeDetailsControl(Employee employee)
        {
            InitializeComponent();
            Employee = employee;
            DataContext = this;  // Set the DataContext to the current instance (the control)
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            // Close the floating window
            var parentWindow = Window.GetWindow(this);
            parentWindow?.Close();
        }
    }
}
