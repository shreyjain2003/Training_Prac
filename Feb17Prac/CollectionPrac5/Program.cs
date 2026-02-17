using System;
using System.Collections.Generic;
namespace CollectionPrac5
{
    public class Employee
    {
        public int EmpId {get; set;}
        public string Name {get; set;}
        public string Job {get; set;}
        public int Salary {get; set;}
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Employee> employee = new List<Employee>();
            employee.Add(new Employee
            {
               EmpId = 101,
               Name = "Shrey",
               Job = "Sr. Software Developer",
               Salary = 90000
            });
            employee.Add(new Employee
            {
               EmpId = 102,
               Name = "Apurav",
               Job = "Analyst",
               Salary = 56000 
            });
            employee.Add(new Employee
            {
               EmpId = 103,
               Name = "Rajpreet",
               Job = "Consultant",
               Salary = 60000 
            });
            employee.Add(new Employee
            {
                EmpId = 104,
                Name = "Tushar",
                Job = "Jr. Software Developer",
                Salary = 75000
            });
            employee.Add(new Employee
            {
                EmpId = 105,
                Name = "Anshul",
                Job = "Clerk",
                Salary = 30000
            });

            foreach(Employee emp in employee)
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Employee ID: "+emp.EmpId);
                Console.WriteLine("Employee Name: "+emp.Name);
                Console.WriteLine("Job Role: "+emp.Job);
                Console.WriteLine("Salary: "+emp.Salary);
                Console.WriteLine("-------------------------------------");
            }
        }
    }
}