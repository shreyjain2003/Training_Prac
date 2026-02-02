// using System;

// /// <summary>
// /// This is a simple generic program in which we have to make student class and add student records, their name, subject and marks using generic
// /// and return the average marks of each student.
// /// after that if the average marks is less than 40 then using delegate
// /// return that student name who is fail otherwise return pass.
// /// 1. Create a Student class with properties Name, Subject, Marks
// /// 2. Create a Generic class to add student records and calculate average marks
// /// 3. Create a delegate to check if the student is pass or fail based on average marks
// /// 4. In the Main method, add student records, calculate average marks and use
// /// </summary>
// namespace GenericPrac1
// {
//     public class Student
//     {
//         public string Name { get; set; }
//         public string Subject { get; set; }
//         public int Marks { get; set; }

//         public Student(string name, string subject, int marks)
//         {
//             Name = name;
//             Subject = subject;
//             Marks = marks;
//         }
//     }
//     public class GenericStudent<T> where T : Student
//     {
//         private List<T> students = new List<T>();
//         public void AddStudent(T student)
//         {
//             students.Add(student);
//         }
//         public List<T> GetAllStudents()
//         {
//             returnn students;
//         }
//         public double CalculateAverageMarks(string studentName)
//         {
//             var studentRecords = students.Where(s => s.Name == studentName).ToList();
//             if (studentRecords.Count == 0)
//             {
//                 throw new Exception("Student not found!");
//             }
//             double totalMarks = studentRecords.Sum(s => s.Marks);
//             return totalMarks / studentRecords.Count;

//         }

//     }
//     public delegate string ResultDelegate(string studentName, double averageMarks, double passMarks);
//     public class Program
//     {
//         static void Main(string[] args)
//         {

//             Console.WriteLine("Enter the number of students: ");
//             int number = int.Parse(Console.ReadLine());
//             GenericStudent<Student> genericStudent = new GenericStudent<Student>();

//             for (int i = 0; i < number; i++)
//             {
//                 Console.WriteLine($"Enter details for Student {i + 1} (Name Subject Marks): ");
//                 string[] input = Console.ReadLine().Split(' ');
//                 string name = input[0];
//                 string subject = input[1];
//                 int marks = int.Parse(input[2]);
//                 genericStudent.AddStudent(new Student(name, subject, marks));
//             }


//             string CheckResult(string studentName, double averageMarks, double passMarks)
//             {
//                 if (averageMarks < passMarks)
//                 {
//                     return $"{studentName} is Fail";
//                 }
//                 else
//                 {
//                     return $"{studentName} is Pass";
//                 }
//             }

//             ResultDelegate resultDelegate = CheckResult;
//             double passMarks = 40;

//             // Get unique student names from existing records
//             var uniqueStudentNames = genericStudent
//                 .GetAllStudents()
//                 .Select(s => s.Name)
//                 .Distinct();

//             foreach (var studentName in uniqueStudentNames)
//             {
//                 double avgMarks = genericStudent.CalculateAverageMarks(studentName);
//                 string result = resultDelegate(studentName, avgMarks, passMarks);

//                 Console.WriteLine($"{studentName} Average Marks: {avgMarks:F2}, Result: {result}");
//             }

//         }
//     }
// }



using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericPrac1
{
    /// <summary>
    /// This is a simple generic program in which we have to make student class and add student records, their name, subject and marks using generic
    /// and return the average marks of each student.
    /// after that if the average marks is less than 40 then using delegate
    /// return that student name notify who is fail otherwise return pass.
    /// </summary>
    public class Student
    {
        public string Name { get; set; }
        public string Subject { get; set; }
        public int Marks { get; set; }

        public Student(string name, string subject, int marks)
        {
            Name = name;
            Subject = subject;
            Marks = marks;
        }
    }

    // Generic class to manage student records
    public class GenericStudent<T> where T : Student
    {
        private List<T> students = new List<T>(); // List to store student records

        public void AddStudent(T student) // Method to add a student record
        {
            students.Add(student);
        }

        public List<T> GetAllStudents() // Method to get all student records
        {
            return students;
        }

        // Method to calculate average marks for a given student
        public double CalculateAverageMarks(string studentName)
        {
            var studentRecords = students.Where(s => s.Name == studentName).ToList(); // Filter records by student name

            if (studentRecords.Count == 0)
                throw new Exception("Student not found!");

            double totalMarks = studentRecords.Sum(s => s.Marks);
            return totalMarks / studentRecords.Count;
        }
    }

    // Delegate to check pass/fail status
    public delegate string ResultDelegate(string studentName, double averageMarks, double passMarks);

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of students: ");
            int number = int.Parse(Console.ReadLine() ?? "0");

            GenericStudent<Student> genericStudent = new GenericStudent<Student>(); // Create instance of GenericStudent

            for (int i = 0; i < number; i++)
            {
                Console.WriteLine($"Enter details for Student {i + 1} (Name Subject Marks): ");
                string[] input = (Console.ReadLine() ?? "").Split(' ');

                string name = input[0];
                string subject = input[1];
                int marks = int.Parse(input[2]);

                genericStudent.AddStudent(new Student(name, subject, marks));
            }

            string CheckResult(string studentName, double averageMarks, double passMarks) // Method to check if student passed or failed
            {
                return averageMarks < passMarks
                    ? $"{studentName} is Fail"
                    : $"{studentName} is Pass";
            }

            ResultDelegate resultDelegate = CheckResult;
            double passMarks = 40;

            var uniqueStudentNames = genericStudent
                .GetAllStudents()
                .Select(s => s.Name)
                .Distinct();

            foreach (var studentName in uniqueStudentNames) // Iterate through unique student names
            {
                double avgMarks = genericStudent.CalculateAverageMarks(studentName);
                string result = resultDelegate(studentName, avgMarks, passMarks);

                Console.WriteLine($"{studentName} Average Marks: {avgMarks:F2}, Result: {result}");
                
            }
        }
    }
}
