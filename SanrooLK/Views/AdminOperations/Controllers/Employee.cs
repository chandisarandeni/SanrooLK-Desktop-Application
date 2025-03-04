using System.ComponentModel;

namespace SanrooLK.Views.AdminOperations.Views
{
    public class Employee : INotifyPropertyChanged
    {
        private string _employeeID;
        private string _employeeName;
        private string _nic;
        private string _contact;

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

        public string NIC
        {
            get { return _nic; }
            set
            {
                if (_nic != value)
                {
                    _nic = value;
                    OnPropertyChanged(nameof(NIC));
                }
            }
        }

        public string Contact
        {
            get { return _contact; }
            set
            {
                if (_contact != value)
                {
                    _contact = value;
                    OnPropertyChanged(nameof(Contact));
                }
            }
        }

        // Implementing INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
