namespace HospitalPatientManagementSystem
{
    public class HospitalManager
    {
        private Dictionary<int, Patient> _patients = new Dictionary<int, Patient>();
        private Queue<Patient> _appointmentQueue = new Queue<Patient>();
        public void RegisterPatient(int id, string name, int age, string condition)
        {
            if(!_patients.ContainsKey(id))
            {
                _patients[id] = new Patient(id, name, age, condition);
            }
        }

        public void ScheduleAppointment(int patientId)
        {
            if(_patients.TryGetValue(patientId, out var patient))
            {
                _appointmentQueue.Enqueue(patient);
            }
        }

        public Patient ProcessNextAppointment()
        {
            return _appointmentQueue.Count > 0 ? _appointmentQueue.Dequeue() : null;
        } 

        public List<Patient> FindPatientsByCondition(string condition)
        {
            return _patients.Values
                .Where(p=> p.Condition.Equals(condition, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }   
    }
}