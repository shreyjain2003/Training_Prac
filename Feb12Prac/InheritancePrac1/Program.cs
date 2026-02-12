// 1. Create a simple base class `Animal` with a method 
// `Speak()`. Derive a `Dog` class that overrides it.


using System;
namespace InheritancePrac1
{
    public class Animal
    {
        public virtual void Speak()
        {
            Console.WriteLine("Animal can Speak.");
        }
    }
    public class Dog : Animal
    {
        public override void Speak()
        {
            Console.WriteLine("Dog Barks.");
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Animal aa = new Animal();
            aa.Speak();
            Animal bb = new Dog();
            bb.Speak();
        }
    }
}