//Create a `Vehicle` class with `StartEngine()`. 
//Extend it to `Car` and `Motorcycle` with different 
//behaviors.

using System;
namespace InheritancePrac4
{
    public class Vehicle
    {
        public virtual void StartEngine()
        {
            Console.WriteLine("Vehicle's Engine started!");
        }
    }
    public class Car : Vehicle
    {
        public override void StartEngine()
        {
            Console.WriteLine("Car's Engine started!");
        }
    }
    public class Motorcycle : Vehicle
    {
        public override void StartEngine()
        {
            Console.WriteLine("Motorcycle's Engine started!");
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Vehicle v1 = new Car();
            Vehicle v2 = new Motorcycle();
            Vehicle v3 = new Vehicle();
            v1.StartEngine();
            v2.StartEngine();
            v3.StartEngine();
        }
    }
}