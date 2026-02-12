// Create a `Person` class with a method `GetDetails()`. Derive `Teacher` and `Student` classes that 
// override the method to provide specific details.
using System;
namespace AdvanceQues4
{
    public class Person
    {
        public virtual void GetDetails()
        {
            Console.WriteLine("Person's Details.");
        }
    }
    public class Teacher : Person
    {
        public override void GetDetails()
        {
            Console.WriteLine("Teacher's Details.");
        }
    }
    public class Student : Person
    {
        public override void GetDetails()
        {
            Console.WriteLine("Student's Details.");
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Person d1= new Student();
            Person d2 = new Teacher();
            d1.GetDetails();
            d2.GetDetails();
        }
    }
}
