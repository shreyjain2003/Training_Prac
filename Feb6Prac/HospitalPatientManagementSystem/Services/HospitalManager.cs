using System;
using HospitalPatientManagementSystem.Models;

namespace HospitalPatientManagementSystem.Services
{
    public class HospitalManager
    {
        private readonly List<Patient> patients=new();
        private readonly List<Doctor> doctors=new();
        private readonly List<Appointment> appointments=new();

        private int patientCounter = 1;
        private int doctorCounter = 1;
        private int appointmentCounter = 1;
        
        public void AddPatient(string name, int age, string bloodGroup)
        {
            patients.Add(new Patient
            {
                PatientId = patientCounter++,
                Name = name,
                Age = age,
                BloodGroup = bloodGroup
            });
        }

        public void AddDoctor(string name, string specialization)
        {
            doctors.Add(new Doctor
            {
                DoctorId = doctorCounter++,
                Name = name,
                Specialization = specialization,
            });   
        }

        public bool ScheduleAppointment(int patientId, int doctorId, DateTime time)
        {
            var patientExists = patients.Any(p=> p.PatientId == patientId);
            var doctorExists = doctors.Any(d=> d.DoctorId == doctorId);

            if(!patientExists || !doctorExists)
            {
                return false;
            }

            appointments.Add(new Appointment
            {
                AppointmentId = appointmentCounter++,
                PatientId = patientId,
                DoctorId = doctorId,
                AppointmentTime = time,
                Status = "Scheduled"
            });

            return true;
        }

        public Dictionary<string, List<Doctor>> GroupDoctorsBySpecialization()
        {
            return doctors
                .GroupBy(d=> d.Specialization)
                .ToDictionary(d=> d.Key,d=> d.ToList());
        }

        public List<Appointment> GetTodayAppointments()
        {
            DateTime today = DateTime.Today;

            return appointments
                .Where(a=> a.AppointmentTime.Date == today)
                .ToList();
        }
    }
}