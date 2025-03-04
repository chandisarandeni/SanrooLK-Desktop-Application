using System.ComponentModel;

namespace SanrooLK.Models
{
    public class Employee : INotifyPropertyChanged
    {
        private string _employeeID;
        private string _employeeName;
        private string _employeeNIC;
        private string _employeeContact;
        private string _employeeEmail;

        public string EmployeeID
        {
            get { return _employeeID; }
            set
            {
                if (_employeeID != value)
                {
                    _employeeID = value;
                    OnPropertyChanged(nameof(EmployeeID));
                }
            }
        }

        public string EmployeeName
        {
            get { return _employeeName; }
            set
            {
                if (_employeeName != value)
                {
                    _employeeName = value;
                    OnPropertyChanged(nameof(EmployeeName));
                }
            }
        }

        public string EmployeeNIC
        {
            get { return _employeeNIC; }
            set
            {
                if (_employeeNIC != value)
                {
                    _employeeNIC = value;
                    OnPropertyChanged(nameof(EmployeeNIC));
                }
            }
        }

        public string EmployeeContact
        {
            get { return _employeeContact; }
            set
            {
                if (_employeeContact != value)
                {
                    _employeeContact = value;
                    OnPropertyChanged(nameof(EmployeeContact));
                }
            }
        }

        public string EmployeeEmail
        {
            get { return _employeeEmail; }
            set
            {
                if (_employeeEmail != value)
                {
                    _employeeEmail = value;
                    OnPropertyChanged(nameof(EmployeeEmail));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
