// Create a `Device` class with a method `TurnOn()`. Derive `Laptop` and `Smartphone` classes that override the method
// to provide specific behaviors.

using System;
namespace AdvanceQues6
{
    public class Device
    {
        public virtual void TurnOn()
        {
            Console.WriteLine("Device Turned on!");
        }
    }
    public class Laptop : Device
    {
        public override void TurnOn()
        {
            Console.WriteLine("Laptop Turned On!");
        }
    }
    public class Smartphone : Device
    {
        public override void TurnOn()
        {
            Console.WriteLine("Smartphone Turned On!");
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Device t1 = new Laptop();
            Device t2 = new Smartphone();
            t1.TurnOn();
            t2.TurnOn();
        }
    }
}