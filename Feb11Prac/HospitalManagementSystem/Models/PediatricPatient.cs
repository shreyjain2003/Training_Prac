using System;
using HospitalManagementSystem.Interfaces;

namespace HospitalManagementSystem.Models
{
    /// <summary>
    /// Represents a pediatric (child) patient.
    /// </summary>
    public class PediatricPatient : IPatient
    {
        public int PatientId { get; set; }
        public required string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public BloodType BloodType { get; set; }

        public required string GuardianName { get; set; }
        public double Weight { get; set; } // in kg
    }
}
