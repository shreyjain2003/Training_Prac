using System;
using System.Collections.Generic;
using System.Linq;
using UniversityRegistrationSystem.Interfaces;

namespace UniversityRegistrationSystem.Services
{
    /// <summary>
    /// Represents a generic grade book system that manages grades
    /// for students enrolled in courses.
    /// </summary>
    /// <typeparam name="TStudent">Student type implementing IStudent</typeparam>
    /// <typeparam name="TCourse">Course type implementing ICourse</typeparam>
    public class GradeBook<TStudent, TCourse>
        where TStudent : IStudent
        where TCourse : ICourse
    {
        private readonly EnrollmentSystem<TStudent, TCourse> _enrollmentSystem;

        // Stores grades using (Student, Course) as composite key
        private readonly Dictionary<(TStudent Student, TCourse Course), double> _grades 
            = new();

        /// <summary>
        /// Initializes a new instance of GradeBook.
        /// </summary>
        /// <param name="enrollmentSystem">
        /// Enrollment system to validate whether student is enrolled.
        /// </param>
        public GradeBook(EnrollmentSystem<TStudent, TCourse> enrollmentSystem)
        {
            _enrollmentSystem = enrollmentSystem 
                ?? throw new ArgumentNullException(nameof(enrollmentSystem));
        }

        /// <summary>
        /// Adds a grade for a student in a course.
        /// </summary>
        /// <param name="student">Student receiving grade</param>
        /// <param name="course">Course for which grade is assigned</param>
        /// <param name="grade">Grade value (0-100)</param>
        /// <exception cref="ArgumentException">
        /// Thrown if grade is outside valid range.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown if student is not enrolled in course.
        /// </exception>
        public void AddGrade(TStudent student, TCourse course, double grade)
        {
            if (student == null)
                throw new ArgumentNullException(nameof(student));

            if (course == null)
                throw new ArgumentNullException(nameof(course));

            if (grade < 0 || grade > 100)
                throw new ArgumentException("Grade must be between 0 and 100.");

            // Validate enrollment
            var enrolledStudents = _enrollmentSystem.GetEnrolledStudents(course);

            if (!enrolledStudents.Any(s => s.StudentId == student.StudentId))
                throw new InvalidOperationException("Student is not enrolled in this course.");

            _grades[(student, course)] = grade;
        }

        /// <summary>
        /// Calculates GPA for a student weighted by course credits.
        /// </summary>
        /// <param name="student">Student whose GPA is calculated</param>
        /// <returns>Weighted GPA or null if no grades found</returns>
        public double? CalculateGPA(TStudent student)
        {
            if (student == null)
                throw new ArgumentNullException(nameof(student));

            var studentGrades = _grades
                .Where(g => g.Key.Student.StudentId == student.StudentId)
                .ToList();

            if (!studentGrades.Any())
                return null;

            double totalWeightedScore = 0;
            int totalCredits = 0;

            foreach (var entry in studentGrades)
            {
                totalWeightedScore += entry.Value * entry.Key.Course.Credits;
                totalCredits += entry.Key.Course.Credits;
            }

            return Math.Round(totalWeightedScore / totalCredits, 2);
        }

        /// <summary>
        /// Returns the top-performing student in a given course.
        /// </summary>
        /// <param name="course">Course to evaluate</param>
        /// <returns>
        /// Tuple of student and grade if exists; otherwise null.
        /// </returns>
        public (TStudent student, double grade)? GetTopStudent(TCourse course)
        {
            if (course == null)
                throw new ArgumentNullException(nameof(course));

            var courseGrades = _grades
                .Where(g => EqualityComparer<TCourse>.Default.Equals(g.Key.Course, course))
                .ToList();

            if (!courseGrades.Any())
                return null;

            var topEntry = courseGrades
                .OrderByDescending(g => g.Value)
                .First();

            return (topEntry.Key.Student, topEntry.Value);
        }
    }
}
