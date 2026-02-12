using System;
using System.Collections.Generic;
using System.Linq;
using HospitalManagementSystem.Interfaces;

namespace HospitalManagementSystem.Services
{
    /// <summary>
    /// Generic priority queue for patients.
    /// Lower number = higher priority.
    /// </summary>
    public class PriorityQueue<T> where T : IPatient
    {
        private readonly SortedDictionary<int, Queue<T>> _queues = new();

        /// <summary>
        /// Enqueues patient with priority (1-5).
        /// </summary>
        public void Enqueue(T patient, int priority)
        {
            if (priority < 1 || priority > 5)
                throw new ArgumentOutOfRangeException(nameof(priority),
                    "Priority must be between 1 (highest) and 5 (lowest).");

            if (!_queues.ContainsKey(priority))
                _queues[priority] = new Queue<T>();

            _queues[priority].Enqueue(patient);
        }

        /// <summary>
        /// Removes and returns highest priority patient.
        /// </summary>
        public T Dequeue()
        {
            foreach (var level in _queues.OrderBy(q => q.Key))
            {
                if (level.Value.Count > 0)
                    return level.Value.Dequeue();
            }

            throw new InvalidOperationException("No patients in queue.");
        }

        /// <summary>
        /// Returns next patient without removing.
        /// </summary>
        public T Peek()
        {
            foreach (var level in _queues.OrderBy(q => q.Key))
            {
                if (level.Value.Count > 0)
                    return level.Value.Peek();
            }

            throw new InvalidOperationException("No patients in queue.");
        }

        /// <summary>
        /// Returns number of patients for specific priority.
        /// </summary>
        public int GetCountByPriority(int priority)
        {
            return _queues.ContainsKey(priority)
                ? _queues[priority].Count
                : 0;
        }
    }
}
