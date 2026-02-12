using System;
using HospitalManagementSystem.Interfaces;
using HospitalManagementSystem.Models;
using HospitalManagementSystem.Services;

namespace HospitalManagementSystem
{
    /// <summary>
    /// Hospital workflow simulation.
    /// </summary>
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("===== HOSPITAL SYSTEM SIMULATION =====\n");

            var child1 = new PediatricPatient
            {
                PatientId = 1,
                Name = "Aarav",
                DateOfBirth = new DateTime(2015, 5, 10),
                BloodType = BloodType.O,
                GuardianName = "Mr. Sharma",
                Weight = 18
            };

            var elderly1 = new GeriatricPatient
            {
                PatientId = 2,
                Name = "Mr. Verma",
                DateOfBirth = new DateTime(1950, 2, 20),
                BloodType = BloodType.AB,
                MobilityScore = 4
            };

            // Priority Queue
            var queue = new PriorityQueue<IPatient>();
            queue.Enqueue(child1, 2);
            queue.Enqueue(elderly1, 1);

            Console.WriteLine($"Next Patient: {queue.Peek().Name}");
            Console.WriteLine($"Processing: {queue.Dequeue().Name}");

            // Medical Record
            var record = new MedicalRecord<PediatricPatient>(child1);
            record.AddDiagnosis("Flu", DateTime.Now);
            record.AddTreatment("Paracetamol", DateTime.Now);

            Console.WriteLine("\nTreatment History:");
            foreach (var entry in record.GetTreatmentHistory())
                Console.WriteLine($"{entry.Key}: {entry.Value}");

            // Medication
            var medSystem = new MedicationSystem<PediatricPatient>();

            medSystem.PrescribeMedication(child1, "Ibuprofen",
                p => p.Weight > 15); // weight-based validation

            Console.WriteLine("\nMedication Prescribed Successfully.");

            Console.WriteLine("\n===== SIMULATION COMPLETE =====");
        }
    }
}
