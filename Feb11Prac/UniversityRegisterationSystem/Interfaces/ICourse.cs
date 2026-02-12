namespace UniversityRegistrationSystem.Interfaces
{
    /// <summary>
    /// Represents a course entity.
    /// </summary>
    public interface ICourse
    {
        string CourseCode { get; }
        string Title { get; }
        int MaxCapacity { get; }
        int Credits { get; }
    }
}
