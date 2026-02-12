using System;

namespace HospitalManagementSystem.Interfaces
{
    /// <summary>
    /// Represents a hospital patient.
    /// </summary>
    public interface IPatient
    {
        int PatientId { get; }
        string Name { get; }
        DateTime DateOfBirth { get; }
        BloodType BloodType { get; }
    }

    public enum BloodType { A, B, AB, O }
}
