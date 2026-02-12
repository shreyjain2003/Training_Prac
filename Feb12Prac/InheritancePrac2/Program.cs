// Create a `Person` class with a method `GetDetails()`.
//  Derive a `Student` class that overrides it.

using System;
namespace InheritancePrac2
{
    public class Person
    {
        public virtual void GetDetails()
        {
            Console.WriteLine("This is a Person");
        }
    }
    public class Student : Person
    {
        public override void GetDetails()
        {
            Console.WriteLine("This ia a Student");
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Person p = new Student();
            p.GetDetails();
        }
    }
}