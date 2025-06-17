using System.Globalization;
using HospitalPatientManagement.Models;

namespace HospitalPatientManagement
{
    /// <summary>
    /// Main program class to run the hospital patient manager.
    /// </summary>
    public class Program
    {
        private Patient[] _patients = Array.Empty<Patient>();
        private KeyEventDispatcher _keyDispatcher = new KeyEventDispatcher();

        /// <summary>
        /// Entry point of the application.
        /// </summary>
        public static void Main()
        {
            new Program().Run();
        }

        /// <summary>
        /// Runs the main application logic.
        /// </summary>
        public void Run()
        {
            LoadPatientsFromFile("patients.txt");

            if (_patients.Length == 0)
            {
                Console.WriteLine("No patients loaded. Press any key to exit.");
                Console.ReadKey();
                return;
            }

            foreach (var patient in _patients)
            {
                _keyDispatcher.KeyPressed += key =>
                {
                    if (key == ConsoleKey.D1) patient.HandleHomeKey();
                    else if (key == ConsoleKey.D2) patient.HandleEndKey();
                };
            }

            bool running = true;
            while (running)
            {
                Console.Clear();
                DisplayPatients();
                DisplayMenu();

                var key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.D1:
                        _keyDispatcher.Dispatch(ConsoleKey.D1);
                        Console.Clear();
                        Console.WriteLine("\n[1] Halved durations. Updated patient list:\n");
                        DisplayPatients();
                        Pause();
                        break;
                    case ConsoleKey.D2:
                        _keyDispatcher.Dispatch(ConsoleKey.D2);
                        Console.Clear();
                        Console.WriteLine("\n[2] Increased durations by 50%. Updated patient list:\n");
                        DisplayPatients();
                        Pause();
                        break;
                    case ConsoleKey.D3:
                        RemoveYoungPatients();
                        Pause();
                        break;
                    case ConsoleKey.D4:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid key. Press any key to continue...");
                        Pause();
                        break;
                }
            }
        }

        /// <summary>
        /// Loads patient data from a file.
        /// </summary>
        private void LoadPatientsFromFile(string fileName)
        {
            try
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);

                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"Error: File '{fileName}' not found.");
                    return;
                }

                var lines = File.ReadAllLines(filePath)
                    .Where(line => !string.IsNullOrWhiteSpace(line) && char.IsDigit(line.Trim()[0]));

                _patients = lines.Select(ParsePatientLine).Where(p => p != null).ToArray()!;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading patients: {ex.Message}");
            }
        }

        /// <summary>
        /// Parses a single line from the file into a Patient object.
        /// </summary>
        private Patient? ParsePatientLine(string line)
        {
            try
            {
                var parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length < 6)
                {
                    Console.WriteLine($"Skipping invalid line: {line}");
                    return null;
                }

                return new Patient(
                    lastName: parts[1],
                    diagnosis: parts[2],
                    admissionDate: ParseDate(parts[3]),
                    dischargeDate: ParseDate(parts[4]),
                    age: int.Parse(parts[5]),
                    department: parts.Length > 6 ? parts[6] : "General");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing line: {line}, {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Parses a date string in format dd.mm.yy.
        /// </summary>
        private static DateTime ParseDate(string dateStr)
        {
            return DateTime.ParseExact(dateStr, "dd.mm.yy", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Displays the list of patients.
        /// </summary>
        private void DisplayPatients()
        {
            var sorted = _patients.OrderBy(p => p.Diagnosis).ToArray();
            Console.WriteLine("ID  Last Name      Diagnosis      Stay Age Department");

            for (int i = 0; i < sorted.Length; i++)
            {
                Console.WriteLine($"{i + 1,-3} {sorted[i].LastName,-14} {sorted[i].Diagnosis,-14} {sorted[i].StayDuration,4} {sorted[i].Age,3} {sorted[i].Department}");
            }
        }

        /// <summary>
        /// Displays the control menu.
        /// </summary>
        private void DisplayMenu()
        {
            Console.WriteLine("\nChoose an option by pressing a number:");
            Console.WriteLine("1 - Halve treatment durations");
            Console.WriteLine("2 - Increase durations by 50%");
            Console.WriteLine("3 - Remove patients under 14");
            Console.WriteLine("4 - Exit application");
            Console.Write("Key: ");
        }

        /// <summary>
        /// Removes all patients under 14 years old.
        /// </summary>
        private void RemoveYoungPatients()
        {
            int countBefore = _patients.Length;
            _patients = _patients.Where(p => p.Age >= 14).ToArray();
            int removed = countBefore - _patients.Length;

            Console.Clear();
            Console.WriteLine($"\n[3] Removed {removed} patients under 14. Updated list:\n");
            DisplayPatients();
        }

        /// <summary>
        /// Pauses the program until a key is pressed.
        /// </summary>
        private void Pause()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey(true);
        }
    }
}
