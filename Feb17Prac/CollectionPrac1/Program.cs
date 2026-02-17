using System;
using System.Collections;

namespace CollectionPrac1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ArrayList al = new ArrayList();
            Console.WriteLine("Enter the number of people records you want to enter: ");
            int num = int.Parse(Console.ReadLine());
            string Name = "";
            int Age = 0;
            string Email = "";
            long Phone = 0;
            for (int i = 0; i < num; i++)
            {
                Hashtable ht = new Hashtable();
                Console.WriteLine("Enter the name of the person: ");
                Name = Console.ReadLine();
                Console.WriteLine("Enter the age: ");
                Age = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the Email: ");
                Email=Console.ReadLine();
                Console.WriteLine("Enter the Phone number: ");
                Phone = long.Parse(Console.ReadLine());
                ht.Add("Name", Name);
                ht.Add("Age", Age);
                ht.Add("Email", Email);
                ht.Add("Phone", Phone);
                al.Add(ht);
            }
            Console.WriteLine("All records: ");
            foreach (Hashtable person in al)
            {
                foreach(var key in person.Keys)
                {
                    Console.WriteLine($"{key}: {person[key]}");
                }
                Console.WriteLine("------------------------------");
            }
        }
    }
}