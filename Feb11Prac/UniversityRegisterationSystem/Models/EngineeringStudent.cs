using UniversityRegistrationSystem.Interfaces;

namespace UniversityRegistrationSystem.Models
{
    /// <summary>
    /// Engineering student implementation.
    /// </summary>
    public class EngineeringStudent : IStudent
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Semester { get; set; }
        public string Specialization { get; set; }
    }
}
