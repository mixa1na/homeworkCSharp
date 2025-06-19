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
        private const char ExitKey = '4';
        private const char FilterByDiagnosisKey = '5';
        private const char FilterByStayLengthKey = '6';
        private const char FilterByAgeKey = '7';

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
                    continue;
                }

                string surname = parts[0];
                bool ageParsed = int.TryParse(parts[1], out int age);
                bool admissionParsed = DateTime.TryParse(parts[2], out DateTime admission);
                bool dischargeParsed = DateTime.TryParse(parts[3], out DateTime discharge);
                string diagnosis = parts[4];
                string department = parts[5];

                if (!ageParsed || !admissionParsed || !dischargeParsed)
                {
                    continue;
                }

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
        /// Handles key press events by performing the corresponding action from the key-action map.
        /// </summary>
        /// <param name="key">The character of the key that was pressed.</param>
        private void HandleKey(char key)
        {
            Dictionary<char, Action> keyActions = new Dictionary<char, Action>
            {
                {
                    HalveStayKey, () =>
                    {
                        foreach (Patient p in _patients)
                        {
                            p.HalveStay();
                        }

                        PrintPatients();
                    }
                },
                {
                    IncreaseStayKey, () =>
                    {
                        foreach (Patient p in _patients)
                        {
                            p.IncreaseStay();
                        }

                        PrintPatients();
                    }
                },
                {
                    RemoveUnderageKey, () =>
                    {
                        _patients = _patients.Where(p => p.Age >= MinimumAge).ToList();
                        PrintPatients();
                    }
                },
                {
                    FilterByDiagnosisKey, () =>
                    {
                        Console.Write("Enter diagnosis to filter by: ");
                        string diagnosis = Console.ReadLine();
                        PrintPatientsByDiagnosis(diagnosis);
                    }
                },
                {
                    FilterByStayLengthKey, () =>
                    {
                        ReadAndExecuteInt(
                            "Enter minimum hospital stay length (days): ",
                            PrintPatientsByMinStayLength);
                    }
                },
                {
                    FilterByAgeKey, () =>
                    {
                        ReadAndExecuteInt(
                            "Enter maximum age: ",
                            PrintPatientsYoungerThan);
                    }
                }                
            };

            bool actionExists = keyActions.TryGetValue(key, out Action action);

            if (actionExists)
            {
                action.Invoke();
            }
            else if (key != ExitKey)
            {
                Console.WriteLine($"Unrecognized key '{key}'. Please try again.");
            }
        }

        /// <summary>
        /// Prompts the user to enter an integer and performs an action if input is valid.
        /// </summary>
        /// <param name="prompt">Text prompt to show to the user.</param>
        /// <param name="onValid">Callback method to invoke if input is valid integer.</param>
        private void ReadAndExecuteInt(string prompt, Action<int> onValid)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            bool success = int.TryParse(input, out int value);

            if (success)
            {
                onValid(value);
            }
            else
            {
                Console.WriteLine("Invalid number entered.");
            }
        }

        /// <summary>
        /// Prints all patients' info to the console in a formatted table.
        /// </summary>
        public void PrintPatients()
        {
            PrintPatientsList(_patients);
        }

        /// <summary>
        /// Prints patients who have the specified diagnosis.
        /// </summary>
        /// <param name="diagnosis">Diagnosis to filter by.</param>
        public void PrintPatientsByDiagnosis(string diagnosis)
        {
            List<Patient> filtered = _patients
                .Where(p => p.Diagnosis.Equals(diagnosis, StringComparison.OrdinalIgnoreCase))
                .ToList();

            PrintPatientsList(filtered);
        }

        /// <summary>
        /// Prints patients with hospital stay length greater than specified days.
        /// </summary>
        /// <param name="minDays">Minimum days of stay.</param>
        public void PrintPatientsByMinStayLength(int minDays)
        {
            List<Patient> filtered = _patients
                .Where(p => p.StayLength > minDays)
                .ToList();

            PrintPatientsList(filtered);
        }

        /// <summary>
        /// Prints patients younger than specified age.
        /// </summary>
        /// <param name="maxAge">Maximum age.</param>
        public void PrintPatientsYoungerThan(int maxAge)
        {
            List<Patient> filtered = _patients
                .Where(p => p.Age < maxAge)
                .ToList();

            PrintPatientsList(filtered);
        }

        /// <summary>
        /// Prints a list of patients to the console in tabular format.
        /// </summary>
        /// <param name="patients">List of patients to print.</param>
        private void PrintPatientsList(List<Patient> patients)
        {
            Console.WriteLine("#  Surname    Diagnosis     Days  Age");

            if (patients.Count == 0)
            {
                Console.WriteLine("No patients found matching criteria.");
                return;
            }

            int index = 1;

            foreach (Patient p in patients)
            {
                string patientInfo = p.GetFormattedInfo();
                string line = string.Format("{0,-3}{1}", index, patientInfo);
                Console.WriteLine(line);
                index++;
            }
        }
    }
}
