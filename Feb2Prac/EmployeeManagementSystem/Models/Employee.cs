using System;
using EmployeeManagementSystem.Services;

namespace EmployeeManagementServices.Models
{
    public class Employee
    {
        public int EmployeeId {get; set;}
        public string Name {get; set;}
        public string Department {get; set;}
        public double Salary {get; set;}
        public DateTime JoiningDate {get; set;}
    }
}

