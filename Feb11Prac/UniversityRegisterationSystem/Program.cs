using System;
using UniversityRegistrationSystem.Models;
using UniversityRegistrationSystem.Services;

namespace UniversityRegistrationSystem
{
    /// <summary>
    /// Entry point for University Registration simulation.
    /// Demonstrates enrollment, grading and GPA calculation.
    /// </summary>
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("===== UNIVERSITY REGISTRATION SYSTEM =====\n");

            // Create Students
            var s1 = new EngineeringStudent
            {
                StudentId = 1,
                Name = "Shreyansh",
                Semester = 5,
                Specialization = "Computer Science"
            };

            var s2 = new EngineeringStudent
            {
                StudentId = 2,
                Name = "Rahul",
                Semester = 3,
                Specialization = "Mechanical"
            };

            var s3 = new EngineeringStudent
            {
                StudentId = 3,
                Name = "Ananya",
                Semester = 6,
                Specialization = "Electronics"
            };

            // Create Courses
            var c1 = new LabCourse
            {
                CourseCode = "CS501",
                Title = "Advanced Programming Lab",
                Credits = 4,
                MaxCapacity = 2,
                RequiredSemester = 4
            };

            var c2 = new LabCourse
            {
                CourseCode = "ME201",
                Title = "Thermodynamics Lab",
                Credits = 3,
                MaxCapacity = 2,
                RequiredSemester = 2
            };

            var enrollment = new EnrollmentSystem<EngineeringStudent, LabCourse>();

            try
            {
                // Successful enrollment
                enrollment.EnrollStudent(s1, c1);
                enrollment.EnrollStudent(s3, c1);

                Console.WriteLine("Enrollment successful for CS501.");

                // Failure due to capacity
                enrollment.EnrollStudent(s2, c1);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Enrollment Error: {ex.Message}");
            }

            try
            {
                enrollment.EnrollStudent(s2, c2);
                Console.WriteLine("Enrollment successful for ME201.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Enrollment Error: {ex.Message}");
            }

            Console.WriteLine("\nStudents in CS501:");
            foreach (var student in enrollment.GetEnrolledStudents(c1))
                Console.WriteLine(student.Name);

            Console.WriteLine($"\nWorkload for {s1.Name}: {enrollment.CalculateStudentWorkload(s1)} credits");

            // GradeBook Simulation
            var gradeBook = new GradeBook<EngineeringStudent, LabCourse>(enrollment);

            gradeBook.AddGrade(s1, c1, 85);
            gradeBook.AddGrade(s3, c1, 92);
            gradeBook.AddGrade(s2, c2, 78);

            Console.WriteLine($"\nGPA for {s1.Name}: {gradeBook.CalculateGPA(s1)}");

            var topStudent = gradeBook.GetTopStudent(c1);
            if (topStudent.HasValue)
                Console.WriteLine($"Top Student in {c1.Title}: {topStudent.Value.student.Name} with {topStudent.Value.grade}");

            Console.WriteLine("\n===== SIMULATION COMPLETE =====");
        }
    }
}
