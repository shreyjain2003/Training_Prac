// Create a `Shape` class with a method `CalculatePerimeter()`. Derive `Rectangle` and `Triangle` classes that override the method
// to calculate their respective perimeters.

using System;
namespace AdvanceQues3
{
    public class Shape
    {
        public virtual double CalculatePerimeter()
        {
            return 0;
        }
    }
    public class Rectangle : Shape
    {
        public double width;
        public double height;
        public Rectangle(double w, double h)
        {
            width = w;
            height = h;
        }
        public override double CalculatePerimeter()
        {
            return 2 * ( width + height);
        }
    }
    public class Triangle : Shape
    {
        public double Side;
        public Triangle(double s)
        {
            Side = s;
        }
        public override double CalculatePerimeter()
        {
            return 3 * Side;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Shape rectangle = new Rectangle(2,3);
            Shape triangle = new Triangle(2);
            Console.WriteLine("Perimeter of Rectangle: "+rectangle.CalculatePerimeter());
            Console.WriteLine("Perimeter of Triangle: "+triangle.CalculatePerimeter());
        }
    }
}