using System;
namespace PracQuestion5
{
    public delegate bool IsEligibleForScholarship(Student std);
    public class Student
    {
        public int RollNo { get; set; }
        public string Name { get; set; }
        public int Marks { get; set; }
        public char SportsGrade { get; set; }

        public static string GetEligibleStudents(List<Student> studentList, IsEligibleForScholarship isEligible)
        {
            if (studentList == null)
            {
                throw new ArgumentNullException(nameof(studentList));
            }
            if (isEligible == null)
            {
                throw new ArgumentNullException(nameof(isEligible));
            }
            List<string> eligibleStudents = new List<string>();
            foreach (var stu in studentList)
            {
                if (isEligible(stu))
                {
                    eligibleStudents.Add(stu.Name);
                }
            }
            return string.Join(", ", eligibleStudents);
        }
    }
    public class Program
    {
        public static bool ScholarshipEligibility(Student std)
        {
            if (std == null)
            {
                throw new ArgumentNullException(nameof(std));
            }
            return std.Marks > 80 && std.SportsGrade == 'A';
        }
        public static void Main(string[] args)
        {
            List<Student> lstStudents = new List<Student>();

            Student obj1 = new Student()
            {
                RollNo = 1,
                Name = "Raj",
                Marks = 75,
                SportsGrade = 'A'
            };

            Student obj2 = new Student()
            {
                RollNo = 2,
                Name = "Rahul",
                Marks = 82,
                SportsGrade = 'A'
            };

            Student obj3 = new Student()
            {
                RollNo = 3,
                Name = "Kiran",
                Marks = 89,
                SportsGrade = 'B'
            };

            Student obj4 = new Student()
            {
                RollNo = 4,
                Name = "Sunil",
                Marks = 86,
                SportsGrade = 'A'
            };

            lstStudents.Add(obj1);
            lstStudents.Add(obj2);
            lstStudents.Add(obj3);
            lstStudents.Add(obj4);

            string result = Student.GetEligibleStudents(
                lstStudents,
                ScholarshipEligibility);

            Console.WriteLine(result);
        }
    }
}