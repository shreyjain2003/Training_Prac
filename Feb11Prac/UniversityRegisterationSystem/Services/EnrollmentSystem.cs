using System;
using System.Collections.Generic;
using System.Linq;
using UniversityRegistrationSystem.Interfaces;

namespace UniversityRegistrationSystem.Services
{
    /// <summary>
    /// Generic enrollment system.
    /// </summary>
    public class EnrollmentSystem<TStudent, TCourse>
        where TStudent : IStudent
        where TCourse : ICourse
    {
        private readonly Dictionary<TCourse, List<TStudent>> _enrollments = new();

        /// <summary>
        /// Enrolls a student in a course with validation.
        /// </summary>
        public bool EnrollStudent(TStudent student, TCourse course)
        {
            if (!_enrollments.ContainsKey(course))
                _enrollments[course] = new List<TStudent>();

            if (_enrollments[course].Count >= course.MaxCapacity)
                throw new InvalidOperationException("Course capacity reached.");

            if (_enrollments[course].Any(s => s.StudentId == student.StudentId))
                throw new InvalidOperationException("Student already enrolled.");

            _enrollments[course].Add(student);
            return true;
        }

        /// <summary>
        /// Returns enrolled students.
        /// </summary>
        public IReadOnlyList<TStudent> GetEnrolledStudents(TCourse course)
            => _enrollments.ContainsKey(course)
                ? _enrollments[course].AsReadOnly()
                : new List<TStudent>().AsReadOnly();

        /// <summary>
        /// Returns courses for a student.
        /// </summary>
        public IEnumerable<TCourse> GetStudentCourses(TStudent student)
            => _enrollments.Where(e => e.Value.Contains(student))
                           .Select(e => e.Key);

        /// <summary>
        /// Calculates total credits for a student.
        /// </summary>
        public int CalculateStudentWorkload(TStudent student)
            => GetStudentCourses(student).Sum(c => c.Credits);
    }
}
