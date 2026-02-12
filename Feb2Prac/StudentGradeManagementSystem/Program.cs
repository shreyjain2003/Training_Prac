using System;
using StudentGradeManagementSystem.Services;

namespace StudentGradeManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SchoolManager manager = new SchoolManager();

            manager.AddStudent("Alice", "10th");
            manager.AddStudent("Bob", "10th");
            manager.AddStudent("Charlie", "11th");

            // Add grades
            manager.AddGrade(1, "Math", 85);
            manager.AddGrade(1, "Science", 90);

            manager.AddGrade(2, "Math", 78);
            manager.AddGrade(2, "Science", 82);

            manager.AddGrade(3, "Math", 92);
            manager.AddGrade(3, "Physics", 88);

            //Group students by grade level
            Console.WriteLine("Students Grouped by Grade Level:");
            var groupedStudents = manager.GroupStudentsByGradeLevel();
            foreach (var grade in groupedStudents)
            {
                Console.WriteLine($"Grade Level: {grade.Key}");
                foreach (var student in grade.Value)
                {
                    Console.WriteLine($" - {student.Name} (ID: {student.StudentId})");
                }
            }

            //3.	Calculate individual student averages
            Console.WriteLine("\nStudent Averages:");
            foreach (var student in manager.GetAllStudents())
            {
                double avg = manager.CalculateStudentAverage(student.StudentId);
                Console.WriteLine($"Student ID: {student.StudentId}, Average: {avg:F2}");
            }


            //4.	Find subject-wise performance
            Console.WriteLine("\nSubject-wise Performance: ");
            var studentAverages = manager.CalculateSubjectAverages();
            foreach (var subAvg in studentAverages)
            {
                Console.WriteLine($"Subject: {subAvg.Key}, Average Grade: {subAvg.Value:F2}");
            }

            //5.	Identify top performers
            Console.WriteLine("\nTop Performers: ");
            var topPerformers = manager.GetTopPerformers(2);
            foreach (var student in topPerformers)
            {
                double avg = manager.CalculateStudentAverage(student.StudentId);
                Console.WriteLine($"Student ID: {student.StudentId}, Name: {student.Name}, Average: {avg:F2}");
            }
        }
    }
}