using System;

namespace HospitalPatientManagementSystem.Models
{
    public class Doctor
    {
        public int DoctorId {get; set;}
        public string Name{get; set;}
        public string Specialization {get; set;}
        public List<DateTime> AvailableSlots {get; set;}
    }
}