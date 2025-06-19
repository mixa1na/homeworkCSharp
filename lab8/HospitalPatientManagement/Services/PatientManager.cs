using HospitalPatientManagement.Models;

namespace HospitalPatientManagement.Services
{
    /// <summary>
    /// Manages a collection of Patient objects and processes commands triggered by key presses.
    /// </summary>
    public class PatientManager
    {
        private const int ExpectedFieldCount = 6;
        private const int MinimumAge = 14;

        private const char HalveStayKey = '1';
        private const char IncreaseStayKey = '2';
        private const char RemoveUnderageKey = '3';

        private List<Patient> _patients;

        /// <summary>
        /// Loads patients from a specified file path into the internal list.
        /// </summary>
        /// <param name="filePath">Path to the text file containing patient data.</param>
        public void LoadPatients(string filePath)
        {
            _patients = new List<Patient>();

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] parts = line.Split(';');

                if (parts.Length != ExpectedFieldCount)
                {
                    // Skip lines that don't have exactly 6 fields
                    continue;
                }

                string surname = parts[0];
                int age = int.Parse(parts[1]);
                DateTime admission = DateTime.Parse(parts[2]);
                DateTime discharge = DateTime.Parse(parts[3]);
                string diagnosis = parts[4];
                string department = parts[5];

                Patient patient = new Patient(
                    surname,
                    age,
                    admission,
                    discharge,
                    diagnosis,
                    department);

                _patients.Add(patient);
            }

            _patients = _patients.OrderBy(p => p.Diagnosis).ToList();
        }

        /// <summary>
        /// Subscribes this manager's handler method to the given KeyHandler's event.
        /// </summary>
        /// <param name="handler">The KeyHandler instance to subscribe to.</param>
        public void Subscribe(KeyHandler handler)
        {
            handler.KeyPressed += HandleKey;
        }

        /// <summary>
        /// Handles key press events by modifying the patient list accordingly.
        /// </summary>
        /// <param name="key">The character of the key that was pressed.</param>
        private void HandleKey(char key)
        {
            if (key == HalveStayKey)
            {
                foreach (Patient p in _patients)
                {
                    p.HalveStay();
                }
            }
            else if (key == IncreaseStayKey)
            {
                foreach (Patient p in _patients)
                {
                    p.IncreaseStay();
                }
            }
            else if (key == RemoveUnderageKey)
            {
                _patients = _patients
                    .Where(p => p.Age >= MinimumAge)
                    .ToList();
            }

            PrintPatients();
        }

        /// <summary>
        /// Prints all patients' info to the console in a formatted table.
        /// </summary>
        public void PrintPatients()
        {
            Console.WriteLine("№  Surname    Diagnosis     Days  Age");

            int index = 1;

            foreach (Patient p in _patients)
            {
                string line = string.Format("{0,-3}{1}", index, p.GetFormattedInfo());
                Console.WriteLine(line);
                index++;
            }
        }
    }
}
