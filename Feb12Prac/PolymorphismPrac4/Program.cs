// Create a `Notification` class with a method `Send()`. Derive `EmailNotification` and `SMSNotification` classes that override the method.
using System;
namespace PolymorphismPrac4
{
    public class Notification
    {
        public virtual void Send()
        {
            Console.WriteLine("Notication Sent!");
        }
    }
    public class EmailNotification : Notification
    {
        public override void Send()
        {
            Console.WriteLine("Email Sent!");
        }
    }
    public class SMSNotification : Notification
    {
        public override void Send()
        {
            Console.WriteLine("SMS Sent!");
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Notification n1 = new EmailNotification();
            Notification n2 = new SMSNotification();
            n1.Send();
            n2.Send();
        }
    }
}