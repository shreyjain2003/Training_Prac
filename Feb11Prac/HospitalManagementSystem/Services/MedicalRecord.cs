using System;
using System.Collections.Generic;
using System.Linq;
using HospitalManagementSystem.Interfaces;

namespace HospitalManagementSystem.Services
{
    /// <summary>
    /// Generic medical record system.
    /// </summary>
    public class MedicalRecord<T> where T : IPatient
    {
        private readonly T _patient;
        private readonly List<(DateTime Date, string Diagnosis)> _diagnoses = new();
        private readonly Dictionary<DateTime, string> _treatments = new();

        public MedicalRecord(T patient)
        {
            _patient = patient ?? throw new ArgumentNullException(nameof(patient));
        }

        /// <summary>
        /// Adds diagnosis entry.
        /// </summary>
        public void AddDiagnosis(string diagnosis, DateTime date)
        {
            if (string.IsNullOrWhiteSpace(diagnosis))
                throw new ArgumentException("Diagnosis cannot be empty.");

            _diagnoses.Add((date, diagnosis));
        }

        /// <summary>
        /// Adds treatment record.
        /// </summary>
        public void AddTreatment(string treatment, DateTime date)
        {
            if (string.IsNullOrWhiteSpace(treatment))
                throw new ArgumentException("Treatment cannot be empty.");

            _treatments[date] = treatment;
        }

        /// <summary>
        /// Returns treatment history sorted by date.
        /// </summary>
        public IEnumerable<KeyValuePair<DateTime, string>> GetTreatmentHistory()
        {
            return _treatments.OrderBy(t => t.Key);
        }
    }
}
