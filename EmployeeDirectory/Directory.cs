using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory
{
    class Directory
    {
        private Employee[] employees;
        public int Count { get; private set; }

        public Directory(int size)
        {
            employees = new Employee[size];
        }

        public Employee[] ListAll()
        {
            Employee[] copy = new Employee[Count];
            int index = 0;
            foreach (Employee employee in employees)
            {
                if (employee != null)
                {
                    copy[index] = employee;
                    index += 1;
                }
            }
            return copy;
        }

        public void Add(Employee employee)
        {
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] == null)
                {
                    employees[i] = employee;
                    Count += 1;
                    break;
                }
            }
        }

        public Employee Remove(Employee employee)
        {
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] == employee)
                {
                    employees[i] = null;
                    Count -= 1;
                    return employee;
                }
            }
            return null;
        }

        public Employee[] Find(string name)
        {
            int count = 0;
            foreach (var employee in employees)
            {
                if (employee?.Name == name)
                {
                    count += 1;
                }
            }
            var result = new Employee[count];
            count = 0;
            foreach (var employee in employees)
            {
                if (employee?.Name == name)
                {
                    result[count] = employee;
                    count += 1;
                }
            }
            return result;
        }
    }
}
