// Implement a `Transport` class with a method `Move()`. Extend it to `Car` and `Bicycle` with different behaviors.
using System;
namespace PolymorphismPrac6
{
    public class Transport
    {
        public virtual void Move()
        {
            Console.WriteLine("Transport is moving.");
        }
    }
    public class Car : Transport
    {
        public override void Move()
        {
            Console.WriteLine("Car is moving.");
        }
    }
    public class Bicycle : Transport
    {
        public override void Move()
        {
            Console.WriteLine("Bicycle is moving.");
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Transport t1 = new Transport();
            Transport t2 = new Car();
            Transport t3 = new Bicycle();
            t1.Move();
            t2.Move();
            t3.Move();
        }
    }
}