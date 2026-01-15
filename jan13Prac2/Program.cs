using System;
using System.Collections.Generic;
using System.Linq;

namespace jan13Prac2
{ 
    public class Student
    {
        public string Name { get; set; }
        public int Mark1 { get; set; }
        public int Mark2 { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>
            {
                new Student { Name = "Shrey", Mark1 = 85, Mark2 = 90 },
                new Student { Name = "Anshul", Mark1 = 75, Mark2 = 80 },
                new Student { Name = "Tushar", Mark1 = 92, Mark2 = 88 },
                new Student { Name = "Sahaj", Mark1 = 75, Mark2 = 85 }
            };

            // Using LINQ to calculate average of Mark1
            var avgMark1 = students.Average(s => s.Mark1);
            Console.WriteLine($"Average of Mark1: {avgMark1}");

            // Using LINQ to calculate average of Mark2
            var avgMark2 = students.Average(s => s.Mark2);
            Console.WriteLine($"Average of Mark2: {avgMark2}");

            // Using LINQ to calculate overall average for each student
            var studentAverages = from s in students
                                  select new
                                  {
                                      s.Name,
                                      Average = (s.Mark1 + s.Mark2) / 2.0
                                  };

            Console.WriteLine("\nStudent-wise averages:");
            foreach (var student in studentAverages)
            {
                Console.WriteLine($"{student.Name}: {student.Average}");
            }
            Console.ReadLine();
        }
    }
}
