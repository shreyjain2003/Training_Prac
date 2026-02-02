using System;
using System.Diagnostics;
using EmployeeManagementSystem.Services;

namespace EmployeeManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            HRManager hr=new HRManager();

            hr.AddEmployee("Shreyansh","IT",90000);
            hr.AddEmployee("Apurav","HR",67000);
            hr.AddEmployee("Tushar","IT",85000);
            hr.AddEmployee("Anshul","Sales",68000);
            hr.AddEmployee("Rajpreet","HR",66000);

            //2.	Display department-wise employee lists

            var deptgroup=hr.GroupEmployeesByDepartment();
            foreach(var dept in deptgroup)
            {
                Console.WriteLine("Department: "+dept.Key);
                foreach(var emp in dept.Value)
                {
                    Console.WriteLine($"ID: {emp.EmployeeId}, Name: {emp.Name}, Salary: {emp.Salary}");
                }
            }

            //3.	Calculate total salary expenditure per department
            foreach(var dept in deptgroup.Keys)
            {
                double totalSalary=hr.CalculateDepartmentSalary(dept);
                Console.WriteLine($"Total Salary Expenditure for {dept}: {totalSalary}");

            }
            //4.	List employees who joined recently.
            var recentEmployee =hr.GetEmployeesJoinedAfter(DateTime.Now.AddMinutes(-1));
            Console.WriteLine("Recently Joined Employees:");
            foreach(var emp in recentEmployee)
            {
                Console.WriteLine($"ID: {emp.EmployeeId}, Name: {emp.Name}, Joining Date: {emp.JoiningDate}");
            }   
        }
    }
}