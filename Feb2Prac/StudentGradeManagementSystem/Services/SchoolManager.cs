using System;
using StudentGradeManagementSystem.Models;

namespace StudentGradeManagementSystem.Services
{
    public class SchoolManager
    {
        private readonly List<Student> students = new();
        private int studentCounter = 1;

        public void AddStudent(string name, string gradeLevel)
        {
            students.Add(new Student
            {
                StudentId = studentCounter++,
                Name = name,
                GradeLevel = gradeLevel
            });
        }
        public List<Student> GetAllStudents()
        {
            return students;
        }

        public void AddGrade(int studentId, string subject, double grade)
        {
            if (grade < 0 || grade > 100)
            {
                throw new ArgumentException("Grade must be between 0 and 100.");
            }
            Student? student = students.FirstOrDefault(s => s.StudentId == studentId);
            if (student == null)
            {
                throw new ArgumentException("Student not found!");
            }
            student.Subjects[subject] = grade;
        }

        public SortedDictionary<string, List<Student>> GroupStudentsByGradeLevel()
        {
            return new SortedDictionary<string, List<Student>>(
                students.GroupBy(s => s.GradeLevel).ToDictionary(g => g.Key, g => g.ToList())
            );
        }

        public double CalculateStudentAverage(int studentId)
        {
            Student? student = students.FirstOrDefault(s => s.StudentId == studentId);
            if (student == null || student.Subjects.Count == 0)
            {
                //throw new ArgumentException("Student not found or has no grades.");
                return 0;
            }
            return student.Subjects.Values.Average();
        }

        public Dictionary<string, double> CalculateSubjectAverages()
        {
            return students
                .SelectMany(s => s.Subjects)
                .GroupBy(s => s.Key)
                .ToDictionary(
                    g => g.Key,
                    g => g.Average(x => x.Value)
                );
        }

        public List<Student> GetTopPerformers(int count)
        {
            return students
                .Where(s => s.Subjects.Count > 0)
                .OrderByDescending(s => s.Subjects.Values.Average())
                .Take(count)
                .ToList();
        }
    }
}
