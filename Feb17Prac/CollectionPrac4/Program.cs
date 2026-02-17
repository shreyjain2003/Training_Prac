using System;
using System.Collections.Generic;
namespace CollectionPrac4 
{
    public class Student : IComparable<Student>
    {
        public int Sid {get;set;}
        public string Name {get; set;}
        public int Class {get; set;}
        public int Marks {get; set;}

        //for sorting in ascending order based on Sid
        public int CompareTo(Student other)
        {
            if(this.Sid > other.Sid)
            {
                return 1;
            }
            else if(this.Sid < other.Sid)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        //for sorting in descending order based on Sid
        // public int CompareTo(Student other)
        // {
        //     if(this.Sid > other.Sid)
        //     {
        //         return -1;
        //     }
        //     else if(this.Sid < other.Sid)
        //     {
        //         return 1;
        //     }
        //     else
        //     {
        //         return 0;
        //     }
        // }
    }

    public class CompareStudents : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            if(x.Marks > y.Marks)
            {
                return 1;
            }
            else if(x.Marks < y.Marks)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
    public class Program
    {
        public static int CompareNames(Student s1, Student s2)
        {
            if(s1.Name.CompareTo(s2.Name) > 0)
            {
                return 1;
            }
            else if(s1.Name.CompareTo(s2.Name) < 0)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        public static void Main(string[] args)
        {
            Student s1 = new Student
            {
                Sid = 104,
                Name = "John Doe",
                Class = 10,
                Marks = 85
            };
            Student s2 = new Student
            {
                Sid = 103,
                Name = "Jane Smith",
                Class = 11,
                Marks = 90
            };
            Student s3 = new Student
            {
                Sid = 105,
                Name = "Bob Johnson",
                Class = 9,
                Marks = 80
            };
            Student s4 = new Student
            {
                Sid = 101,
                Name = "Alice Brown",
                Class = 12,
                Marks = 95
            };
            Student s5 = new Student
            {
                Sid = 102,
                Name = "Charlie Davis",
                Class = 9,
                Marks = 88
            };
            List<Student> students = new List<Student>{s1, s2, s3, s4, s5};
            CompareStudents compareByMark  = new CompareStudents();
            Comparison<Student> compareByNames = new Comparison<Student>(CompareNames);
            //students.Sort(compareByNames); //sorts in ascending order based on Names

            //students.Sort(); //sorts in ascending order based on Sid as per CompareTo method in Student class

            //students.Sort(1,3,compareByMarks);

            //now to get it in reverse order 
            //students.Reverse();
            //students.Sort(delegate (Student S1, Student S2) { return S1.Name.CompareTo(S2.Name);});
            students.Sort((s1,s2) => s1.Name.CompareTo(s2.Name));
            foreach(Student s in students)
            {
                Console.WriteLine($"Student ID: {s.Sid}");
                Console.WriteLine($"Name: {s.Name}");
                Console.WriteLine($"Class: {s.Class}");
                Console.WriteLine($"Marks: {s.Marks}");
                Console.WriteLine("------------------------------");
            }
        }
    }
}