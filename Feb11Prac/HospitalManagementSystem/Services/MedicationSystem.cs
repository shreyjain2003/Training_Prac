using System;
using System.Collections.Generic;
using HospitalManagementSystem.Interfaces;

namespace HospitalManagementSystem.Services
{
    /// <summary>
    /// Generic medication management system.
    /// </summary>
    public class MedicationSystem<T> where T : IPatient
    {
        private readonly Dictionary<T, List<string>> _medications = new();

        /// <summary>
        /// Prescribes medication after validating dosage rules.
        /// </summary>
        public void PrescribeMedication(T patient, string medication, Func<T, bool> dosageValidator)
        {
            if (!dosageValidator(patient))
                throw new InvalidOperationException("Dosage validation failed.");

            if (!_medications.ContainsKey(patient))
                _medications[patient] = new List<string>();

            _medications[patient].Add(medication);
        }

        /// <summary>
        /// Checks for duplicate medication interaction.
        /// </summary>
        public bool CheckInteractions(T patient, string newMedication)
        {
            if (!_medications.ContainsKey(patient))
                return false;

            return _medications[patient].Contains(newMedication);
        }
    }
}
