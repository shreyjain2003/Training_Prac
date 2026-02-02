using System;
using System.Globalization;

namespace DelegateExample2
{
    public class Student
    {
        public string Name {get; set;}
        public int Marks {get; set;}

        public Student(string name, int marks)
        {
            Name=name;
            Marks=marks;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter number of students: ");
            int number =int.Parse(Console.ReadLine());
            List<Student> students=new List<Student>();

            for( int i=0; i <number;i++)
            {
                Console.WriteLine($"Enter details for Student {i+1}. (Name,Marks): ");
                string[] input=Console.ReadLine().Split(',');
                string name=input[0];
                int marks=int.Parse(input[1]);
                students.Add(new Student(name,marks));
            }
            Predicate<Student> isPassed =s => s.Marks >=40;

            Func<Student,string> calculateGrade = s =>
            {
                if(s.Marks >= 75) return "A";
                else if(s.Marks >=60) return "B";
                else if(s.Marks >=40) return "C";
                else return "Fail";
            };

            Action<Student,string> notifyResult =(s, grade) =>
            {
                Console.WriteLine($"Student: {s.Name}, Marks: {s.Marks}, Grade: {grade}");
            };

            Console.WriteLine("Student Results:\n");

            foreach(var student in students)
            {
                bool passed = isPassed(student);
                string grade=calculateGrade(student);
                notifyResult(student,grade);

                if(!passed)
                {
                    Console.WriteLine($"{student.Name} has failed. Additional support will be provided.");
                }
                else
                {
                    Console.WriteLine($"{student.Name} has passed\n");
                }
            }
            Console.WriteLine("Program completed."); 
        }
    }
}