using System;
using HospitalPatientManagementSystem.Services;

namespace HospitalPatientManagementSystem
{
    class Program
    {
        static void Main()
        {
            var manager = new HospitalManager();

            // Add patients
            manager.AddPatient("Amit Kumar", 30, "O+");
            manager.AddPatient("Neha Sharma", 25, "B+");

            // Add doctors
            manager.AddDoctor("Dr. Verma", "Cardiology");
            manager.AddDoctor("Dr. Singh", "Orthopedics");

            // Schedule appointments
            manager.ScheduleAppointment(1, 1, DateTime.Now);
            manager.ScheduleAppointment(2, 2, DateTime.Now.AddHours(2));

            // Group doctors by specialization
            Console.WriteLine("Doctors by Specialization:");
            var groupedDoctors = manager.GroupDoctorsBySpecialization();
            foreach (var group in groupedDoctors)
            {
                Console.WriteLine($"{group.Key}: {group.Value.Count}");
            }

            // Today's appointments
            Console.WriteLine("\nToday's Appointments:");
            foreach (var appt in manager.GetTodayAppointments())
            {
                Console.WriteLine($"PatientId: {appt.PatientId}, DoctorId: {appt.DoctorId}, Time: {appt.AppointmentTime}");
            }
        }
    }
}
