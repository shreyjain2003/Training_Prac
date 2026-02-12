// Implement a `Device` class with a method `Shutdown()`. Extend it to `Laptop` and `Desktop` with different shutdown behaviors.
using System;
namespace PolymorphismPrac8
{
    public class Device
    {
        public virtual void Shutdown()
        {
            
            Console.WriteLine("Device is shutting down.");
        }
    }
    public class Laptop : Device
    {
        public override void Shutdown()
        {
            Console.WriteLine("Laptop is shutting down.");
        }
    }
    public class Desktop : Device
    {
        public override void Shutdown()
        {
            Console.WriteLine("Desktop is shutting down.");
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Device d1 = new Device();
            Device d2 = new Laptop();
            Device d3 = new Desktop();
            d1.Shutdown();
            d2.Shutdown();
            d3.Shutdown();
        }
    }
}