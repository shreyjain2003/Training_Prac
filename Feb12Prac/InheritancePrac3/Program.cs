// Implement an `Employee` base class with a method 
//`CalculateSalary()`. Create a `Manager` class that adds a
// bonus to salary.

using System;
namespace InheritancePrac3
{
    public class Employee
    {
        public virtual int CalculateSalary()
        {
            return 40000;
        }
    }
    public class Manager : Employee
    {
        public override int CalculateSalary()
        {
            return base.CalculateSalary() + 10000;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Employee ee = new Manager();
            Console.WriteLine("Calculated Salary with bonus: "+ee.CalculateSalary());
        }
    }
}