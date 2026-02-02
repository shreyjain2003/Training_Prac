using System;
using System.Collections.Generic;

namespace DelegateExample3
{
    public class NotificationSystem
    {
        public void ProcessTask<T>(T item, Action<T> action)
        {
            Console.WriteLine("Initiating task processing...");
            action(item);
            Console.WriteLine("Task Processing Completed.");
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            NotificationSystem notificationSystem = new NotificationSystem();

            Action<string> sendEmail = message =>
            {
                Console.WriteLine($"Sending Email: {message}");
            };

            Action<string> logToFile = message =>
            {
                Console.WriteLine($"Logging to file: {message}");
            };

            Console.WriteLine("Processing Email Notification:");
            notificationSystem.ProcessTask("Email Notification Message", sendEmail);

            Console.WriteLine("\nProcessing File Log Notification:");
            notificationSystem.ProcessTask("File Log Notification Message", logToFile);
        }
    }
}