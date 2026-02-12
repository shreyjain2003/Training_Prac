// Create a base class `Shape` with a method `Draw()`. 
//Derive `Circle` and `Square` classes that override the `Draw()`
// method.
using System;
namespace PolymorphismPrac1
{
    public class Shape
    {
        public virtual void Draw()
        {
            Console.WriteLine("Drawing Shape!");
        }
    }
    public class Circle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing Circle!");
        }
    }
    public class Square : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing Square!");
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Shape d1=new Shape();
            Shape d2=new Circle();
            Shape d3 = new Square();
            d1.Draw();
            d2.Draw();
            d3.Draw();
        }
    }
}