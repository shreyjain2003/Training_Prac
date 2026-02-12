// Create a base class `Employee` with a method `GetSalary()`. Derive `FullTimeEmployee` and `PartTimeEmployee` classes that override the method
// to calculate salaries differently.

using System;
namespace Advanceques1
{
    public class Employee
    {
        public virtual double GetSalary()
        {
            return 0;
        }
    }
    public class FullTimeEmployee : Employee
    {
        public override double GetSalary()
        {
            return 50000;
        }
    }
    public class PartTimeEmployee : Employee
    {
        public override double GetSalary()
        {
            return 30000;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Employee FullTime = new FullTimeEmployee();
            Employee PartTime = new PartTimeEmployee();
            Console.WriteLine("PartTime Salary: "+PartTime.GetSalary());
            Console.WriteLine("FullTime Salary: "+FullTime.GetSalary());
        }
    }
}