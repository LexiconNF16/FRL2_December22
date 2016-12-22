using System;

namespace EmployeeDirectory
{
    class Employee
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { if (!string.IsNullOrWhiteSpace(value)) name = value; }
        }

        private int salary;
        public int Salary
        {
            get { return salary; }
            set { if (value >= 0) salary = value; }
        }

        public DateTime StartDate { get; set; }

        public int DaysEmployed {
            get { return (int)(DateTime.Today - StartDate).TotalDays; }
            set { StartDate = DateTime.Today.AddDays(-value); }
        }

        public Employee(string name, int salary)
        {
            Name = name;
            Salary = salary;
            StartDate = DateTime.Today;
        }

        public Employee(string name) : this(name, 0)
        {
        }

    }
}
