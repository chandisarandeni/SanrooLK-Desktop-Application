using System;
using System.Windows;
using System.Windows.Controls;
using MongoDB.Driver;
using SanrooLK.Models;  // This should be fine as long as the namespace exists

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

        private void btn_saveEmployee_Click(object sender, RoutedEventArgs e)
        {
            // Get the EmployeeID from the bound Employee object
            string employeeID = Employee.EmployeeID;
            string employeeName = Employee.EmployeeName;

            // Update employee name in MongoDB
            UpdateEmployeeName(employeeID, employeeName);

            // Provide feedback to the user
            MessageBox.Show("Employee name updated successfully!");
        }

        private void UpdateEmployeeName(string employeeID, string employeeName)
        {
            try
            {
                // MongoDB client and database setup
                var client = new MongoClient("mongodb+srv://DesktopClient:6uJegLlg5cjVy5GS@sanroolk.xxwnk.mongodb.net/?retryWrites=true&w=majority&appName=SanrooLK");
                var database = client.GetDatabase("SanrooLKDB");
                var collection = database.GetCollection<Employee>("Employee");

                // Find the employee document by employeeID
                var filter = Builders<Employee>.Filter.Eq(e => e.EmployeeID, employeeID);

                // Create an update definition
                var update = Builders<Employee>.Update.Set(e => e.EmployeeName, employeeName);  // Update only the name

                // Update the employee document
                var result = collection.UpdateOne(filter, update);

                // Log result for debugging
                Console.WriteLine($"Matched count: {result.MatchedCount}, Modified count: {result.ModifiedCount}");

                if (result.ModifiedCount > 0)
                {
                    MessageBox.Show("Employee name updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    Console.WriteLine("Employee name updated successfully.");
                }
                else
                {
                    MessageBox.Show("No changes were made. Employee not found or no updates required.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    Console.WriteLine("No changes were made. Employee not found or no updates required.");
                }
            }
            catch (Exception ex)
            {
                // Catch any exceptions and show a detailed error message
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

    }
}
