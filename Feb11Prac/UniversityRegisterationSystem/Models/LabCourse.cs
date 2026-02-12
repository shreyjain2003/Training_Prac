using UniversityRegistrationSystem.Interfaces;

namespace UniversityRegistrationSystem.Models
{
    /// <summary>
    /// Lab course with prerequisite semester.
    /// </summary>
    public class LabCourse : ICourse
    {
        public string CourseCode { get; set; }
        public string Title { get; set; }
        public int MaxCapacity { get; set; }
        public int Credits { get; set; }
        public int RequiredSemester { get; set; }
    }
}
