// Implement `Shape` class with `CalculateArea()`. Extend to `Rectangle` and `Circle` with area calculations.
using System;

namespace InheritancePrac6
{
    public class Shape
    {
        public virtual void CalculateArea()
        {
            Console.WriteLine("Calculated Area Of Shape."+ 0);
        }
    }
    public class Rectangle : Shape
    {
        private double width;
        private double height;
        public Rectangle(double w,double h)
        {
            width=w;
            height=h;
        }
        public override void CalculateArea()
        {
            double area = width * height;
            Console.WriteLine("Area of Rectangle: "+area);
        }
    }
    public class Circle : Shape
    {
        private double radius;
        public Circle(double r)
        {
            radius=r;
        }
        public override void CalculateArea()
        {
            double area = Math.PI * radius * radius;
            Console.WriteLine("Area of Circle: "+area);
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Shape a1 = new Shape();
            Shape a2 = new Rectangle(2,3);
            Shape a3 = new Circle(2);
            a1.CalculateArea();
            a2.CalculateArea();
            a3.CalculateArea();
        }
    }
}