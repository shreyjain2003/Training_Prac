using System;

namespace UniversityRegistrationSystem.Interfaces
{
    /// <summary>
    /// Represents a student entity.
    /// </summary>
    public interface IStudent
    {
        int StudentId { get; }
        string Name { get; }
        int Semester { get; }
    }
}
