using System;
using System.Globalization;
using System.IO;
using System.Linq;
using HospitalPatientManagement.Models;
using System.Collections.Generic;

namespace HospitalPatientManagement
{
    /// <summary>
    /// Main program class to run the hospital patient manager.
    /// </summary>
    public class Program
    {
        private Patient[] _patients = Array.Empty<Patient>();
        private readonly KeyEventDispatcher _keyDispatcher = new();

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
                    if (key == ConsoleKey.D1)
                    {
                        patient.HandleHomeKey();
                    }
                    else if (key == ConsoleKey.D2)
                    {
                        patient.HandleEndKey();
                    }
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
                    case ConsoleKey.D5:
                        FilterByDiagnosis();
                        Pause();
                        break;
                    case ConsoleKey.D6:
                        FilterByStayDuration();
                        Pause();
                        break;
                    case ConsoleKey.D7:
                        FilterByAge();
                        Pause();
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
        /// <param name="fileName">The name of the file containing patient data.</param>
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
        /// <param name="line">The line to parse.</param>
        /// <returns>The created Patient object or null if parsing fails.</returns>
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
        /// Parses a date string in format dd.MM.yy.
        /// </summary>
        /// <param name="dateStr">The date string to parse.</param>
        /// <returns>A DateTime object.</returns>
        private static DateTime ParseDate(string dateStr)
        {
            return DateTime.ParseExact(dateStr, "dd.MM.yy", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Displays the list of patients sorted by diagnosis.
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
            Console.WriteLine("5 - Filter by diagnosis");
            Console.WriteLine("6 - Filter by stay duration");
            Console.WriteLine("7 - Filter by age");
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
        /// Displays patients with a specified diagnosis.
        /// </summary>
        private void FilterByDiagnosis()
        {
            Console.Write("Enter diagnosis to search: ");
            string? diagnosis = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(diagnosis)) return;

            var filtered = _patients.Where(p => string.Equals(p.Diagnosis, diagnosis, StringComparison.OrdinalIgnoreCase)).ToArray();

            Console.Clear();
            Console.WriteLine($"\nPatients with diagnosis '{diagnosis}':\n");
            DisplayPatientsArray(filtered);
        }

        /// <summary>
        /// Displays patients with stay duration longer than specified.
        /// </summary>
        private void FilterByStayDuration()
        {
            Console.Write("Enter minimum stay duration (days): ");
            if (!int.TryParse(Console.ReadLine(), out int minDays)) return;

            var filtered = _patients.Where(p => p.StayDuration > minDays).ToArray();

            Console.Clear();
            Console.WriteLine($"\nPatients with stay longer than {minDays} days:\n");
            DisplayPatientsArray(filtered);
        }

        /// <summary>
        /// Displays patients younger than a specified age.
        /// </summary>
        private void FilterByAge()
        {
            Console.Write("Enter maximum age: ");
            if (!int.TryParse(Console.ReadLine(), out int maxAge)) return;

            var filtered = _patients.Where(p => p.Age < maxAge).ToArray();

            Console.Clear();
            Console.WriteLine($"\nPatients younger than {maxAge} years:\n");
            DisplayPatientsArray(filtered);
        }

        /// <summary>
        /// Displays a list of patients.
        /// </summary>
        /// <param name="patients">The array of patients to display.</param>
        private void DisplayPatientsArray(Patient[] patients)
        {
            Console.WriteLine("ID  Last Name      Diagnosis      Stay Age Department");
            for (int i = 0; i < patients.Length; i++)
            {
                var p = patients[i];
                Console.WriteLine($"{i + 1,-3} {p.LastName,-14} {p.Diagnosis,-14} {p.StayDuration,4} {p.Age,3} {p.Department}");
            }
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
