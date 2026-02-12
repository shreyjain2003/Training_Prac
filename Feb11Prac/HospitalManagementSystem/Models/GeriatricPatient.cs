using System;
using System.Collections.Generic;
using HospitalManagementSystem.Interfaces;

namespace HospitalManagementSystem.Models
{
    /// <summary>
    /// Represents an elderly patient.
    /// </summary>
    public class GeriatricPatient : IPatient
    {
        public int PatientId { get; set; }
        public required string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public BloodType BloodType { get; set; }

        public List<string> ChronicConditions { get; } = new();
        public int MobilityScore { get; set; } // 1-10
    }
}
