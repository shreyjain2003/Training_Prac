using System;
using System.Collections.Generic;
using System.Linq;
using EmployeeManagementServices.Models;

namespace EmployeeManagementSystem.Services
{
    public class HRManager
    {
        private readonly List<Employee> employees=new();
        private int employeeCounter = 1;

        public void AddEmployee(string name, string dept, double salary)
        {
            employees.Add(new Employee
            {
                EmployeeId= employeeCounter++,
                Name=name,
                Department=dept,
                Salary=salary,
                JoiningDate=DateTime.Now
            });
        }

        public SortedDictionary<string, List<Employee>> GroupEmployeesByDepartment()
        {
            return new SortedDictionary<string,List<Employee>>(
                employees.GroupBy(r=>r.Department).ToDictionary(g=> g.Key,global=>global.ToList())
            );
        }

        public double CalculateDepartmentSalary(string department)
        {
            return employees
                .Where(e => e.Department == department)
                .Sum(e => e.Salary);
        }

        public List<Employee> GetEmployeesJoinedAfter(DateTime date)
        {
            return employees.Where(e=>e.JoiningDate > date).ToList();
        }
    }
}