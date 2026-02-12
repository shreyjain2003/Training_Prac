using System;

namespace StudentGradeManagementSystem.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string GradeLevel { get; set; }
        public Dictionary<string, double> Subjects { get; set; } = new();
    }
}