using System;
using System.Linq;
using System.Collections.Generic;
namespace PracQuestion1
{
    public class Person
    {
        public string Name {get; set;}
        public string Address {get; set;}
        public int Age {get; set;}
    }
    public class PersonImplementation
    {
        public string GetName(IList<Person> person)
        {
            return string.Join(" ",person.Select(p => p.Name+" "+p.Address));            
        }
        public double Average(IList<Person> person)
        {
            return person.Average(p => p.Age);
        }
        public double Max(IList<Person> person)
        {
            return person.Max(p => p.Age);
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            IList<Person> p = new List<Person>();
            p.Add(new Person {Name = "Aarya", Address = "A2101", Age = 69});
            p.Add(new Person {Name = "Daniel", Address = "A2102", Age = 40});
            p.Add(new Person {Name = "Ira", Address = "A2103", Age = 25});
            p.Add(new Person {Name = "Jennifer", Address = "A2104", Age = 33});

            PersonImplementation personImplementation = new PersonImplementation();
            Console.WriteLine(personImplementation.GetName(p));
            Console.WriteLine(personImplementation.Average(p));
            Console.WriteLine(personImplementation.Max(p));
        }
    }
}