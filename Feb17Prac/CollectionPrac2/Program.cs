using System;
using System.Collections.Generic;

namespace CollectionPrac2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Dictionary<string, object>> al = new List<Dictionary<string, object>>();
            Console.WriteLine("Enter the number of people records you want to enter: ");
            int num = int.Parse(Console.ReadLine());
            string Name = "";
            int Age = 0;
            string Email = "";
            long Phone = 0;
            for (int i = 0; i < num; i++)
            {
                Dictionary<string, object> dt = new Dictionary<string, object>();
                Console.WriteLine("Enter the name of the person: ");
                Name = Console.ReadLine();
                Console.WriteLine("Enter the age: ");
                Age = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the Email: ");
                Email = Console.ReadLine();
                Console.WriteLine("Enter the Phone number: ");
                Phone = long.Parse(Console.ReadLine());
                dt.Add("Name", Name);
                dt.Add("Age", Age);
                dt.Add("Email", Email);
                dt.Add("Phone", Phone);
                al.Add(dt);
            }
            Console.WriteLine("--------------All records:-----------------");
            foreach (Dictionary<string, object> person in al)
            {
                foreach (var key in person.Keys)
                {
                    Console.WriteLine($"{key}: {person[key]}");
                }
                Console.WriteLine("------------------------------");
            }
        }
    }
}