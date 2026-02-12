// Implement a `Payment` class with a method `ProcessPayment()`.
// Extend it to `CreditCardPayment` and `PayPalPayment` with 
// different implementations.

using System;
namespace PolymorphismPrac2
{
    public class Payment
    {
        public virtual void ProcessPayment()
        {
            Console.WriteLine("Processing payment");
        }
    }
    public class CreditCardPayment : Payment
    {
        public override void ProcessPayment()
        {
            Console.WriteLine("Processing credit card payment");
        }
    }
    public class PayPalPayment : Payment
    {
        public override void ProcessPayment()
        {
            Console.WriteLine("Processing PayPal payment");
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Payment p1 = new CreditCardPayment();
            p1.ProcessPayment();

            Payment p2 = new PayPalPayment();
            p2.ProcessPayment();
        }
    }
}