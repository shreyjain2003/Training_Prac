using System;
using System.Linq;
using System.Collections.Generic;
namespace LinqPrac1
{
    public class Employee
    {
        public int EmpId { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public int Salary { get; set; }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee
            {
                EmpId = 101,
                Name = "Shrey",
                Department = "Software Engineer",
                Salary = 110000
            });
            employees.Add(new Employee
            {
                EmpId = 102,
                Name = "Rajpreet",
                Department = "Consultant",
                Salary = 60000
            });
            employees.Add(new Employee
            {
                EmpId = 103,
                Name = "Apurav",
                Department = "Analyst",
                Salary = 70000
            });
            employees.Add(new Employee
            {
                EmpId = 104,
                Name = "Anshul",
                Department = "Clerk",
                Salary = 30000
            });
            employees.Add(new Employee
            {
                EmpId = 105,
                Name = "Tushar",
                Department = "Tester",
                Salary = 50000
            });
            // for getting all the data using foreach loop
            foreach (var emp in employees)
            {
                Console.WriteLine($"Employees ID: {emp.EmpId} | Name: {emp.Name} | Department: {emp.Department} | Salary: {emp.Salary}");
            }

            //for getting all data using linq
            employees.ForEach(emp => Console.WriteLine("ID: {0}, Name: {1}, Department: {2}, Salary: {3}", emp.EmpId, emp.Name, emp.Department, emp.Salary));

            // for getting only names using linq
            IEnumerable<string> names = employees.Select(e => e.Name);
            foreach (string name in names)
            {
                Console.Write(name + " ");
            }

            var sorted = employees.OrderBy(e => e.Salary).ToList();
            foreach (var emp in sorted)
            {
                Console.WriteLine(emp.Name + " | " + emp.Department + " | " + emp.Salary);
            }

            var sortedDict = employees.OrderByDescending(e => e.Salary).ToDictionary(e => e.EmpId, e => e);
            foreach (var emp in sortedDict)
            {
                Console.WriteLine($"Employee ID: {emp.Key}");
                Console.WriteLine($"Name: {emp.Value.Name}, Dept: {emp.Value.Department}, Salary: {emp.Value.Salary}");
            }
        }
    }
}