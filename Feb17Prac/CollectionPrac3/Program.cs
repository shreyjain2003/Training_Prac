using System;
using System.Collections.Generic;

namespace CollectionPrac3
{
    public class Customer
    {
        public int CustId {get; set;}
        public string Name {get; set;}
        public string Address {get; set;}
        public int Balance {get; set;}
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Customer> customers = new List<Customer>();
            Customer c1 =new Customer{
                CustId = 1,
                Name = "John Doe",
                Address = "123 Main St",
                Balance = 1000
            };
            Customer c2 = new Customer
            {
                CustId = 2,
                Name = "Jane Smith",
                Address = "456 Elm St",
                Balance = 2000
            };
            Customer c3 = new Customer
            {
                CustId = 3,
                Name = "Bob Johnson",
                Address = "789 Oak St",
                Balance = 1500
            };
            Customer c4 = new Customer
            {
                CustId = 4,
                Name = "Alice Brown",
                Address = "321 Pine St",
                Balance = 2500
            };
            customers.Add(c1);
            customers.Add(c2);
            customers.Add(c3);
            customers.Add(c4);

            foreach(Customer c in customers)
            {
                Console.WriteLine($"Customer ID: {c.CustId}");
                Console.WriteLine($"Name: {c.Name}");
                Console.WriteLine($"Address: {c.Address}");
                Console.WriteLine($"Balance: {c.Balance}");
                Console.WriteLine("------------------------------");
            }
        }
    }
}