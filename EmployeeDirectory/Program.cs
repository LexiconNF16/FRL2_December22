using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory
{
    class Program
    {
        static void Main(string[] args)
        {
            int directorySize = 100;
            Directory directory = new Directory(directorySize);

            bool quit = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Välkommen till personalregistret!");
                Console.WriteLine();
                Console.WriteLine("M. Mata in uppgifter");
                Console.WriteLine("V. Visa personallistan");
                Console.WriteLine("S. Sök efter person");
                Console.WriteLine("Q. Avsluta");

                string selection = AskForString("> ").ToUpper();
                Console.Clear();
                switch (selection)
                {
                    case "M":
                        Console.WriteLine("Ange dina anställdas uppgifter:");
                        AddEmployees(directory);
                        break;
                    case "V":
                        Console.WriteLine("Personalregistret innehåller följande personer:");
                        ListEmployees(directory);
                        break;
                    case "S":
                        FindEmployee(directory);
                        break;
                    case "Q":
                        quit = true;
                        break;
                    default:
                        break;
                }
                Console.Write("Tryck på 'any key' för att fortsätta");
                Console.ReadKey();
            } while (!quit);
        }

        private static void FindEmployee(Directory directory)
        {
            var query = AskForString("Ange namn på personen: ");
            var result = directory.Find(query);
            foreach (var employee in result)
            {
                Console.WriteLine();
                Console.WriteLine("Namn: " + employee.Name);
                Console.WriteLine("Lön:  " + employee.Salary + " kr");
                Console.WriteLine("Start:  " + employee.StartDate);
                Console.WriteLine("Dagar:  " + employee.DaysEmployed);
            }
        }

        private static void ListEmployees(Directory directory)
        {    
            foreach(Employee employee in directory.ListAll()) {
                Console.WriteLine();
                Console.WriteLine("Namn: " + employee.Name);
                Console.WriteLine("Lön:  " + employee.Salary + " kr");
                Console.WriteLine("Start:  " + employee.StartDate);
                Console.WriteLine("Dagar:  " + employee.DaysEmployed);
            }
        }

        private static void AddEmployees(Directory directory)
        {
            while (true)
            {
                Console.WriteLine();

                string name = AskForString("Ange namn: ");
                if (name == "") break;

                int salary = AskForInt("Ange lön: ");
                int days = AskForInt("Hur många dagar har " + name + " varit anställd? ");

                directory.Add(new Employee(name, salary) {
                    DaysEmployed = days
                });
            }
        }

        private static int AskForInt(string question)
        {
            int value;
            bool parsed;
            string error = "";
            do
            {
                string input = AskForString(error + question);
                parsed = int.TryParse(input, out value);
                error = "Jag kunde inte tolka värdet, det får bara innehålla siffror\n";
            } while (!parsed);

            return value;
        }

        private static string AskForString(string question)
        {
            Console.Write(question);
            return Console.ReadLine();
        }
    }
}
