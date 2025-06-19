using HospitalPatientManagement.Services;

namespace HospitalPatientManagement
{
    /// <summary>
    /// Main program class to run the hospital patient management application.
    /// </summary>
    public class Program
    {
        private const string DataFolder = "Data";
        private const string FileName = "patient.txt";
        private const char ExitKey = '4';

        /// <summary>
        /// Main program logic runner.
        /// </summary>
        public void Run()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DataFolder, FileName);

            PatientManager manager = new PatientManager();
            manager.LoadPatients(filePath);

            KeyHandler handler = new KeyHandler();
            manager.Subscribe(handler);

            manager.PrintPatients();

            Console.WriteLine();
            Console.WriteLine("Press a key:");
            Console.WriteLine("1 – Halve hospital stay");
            Console.WriteLine("2 – Increase hospital stay");
            Console.WriteLine("3 – Remove patients under 14");
            Console.WriteLine("4 – Exit");

            bool isRunning = true;

            while (isRunning)
            {
                char key = Console.ReadKey(true).KeyChar;

                if (key == ExitKey)
                {
                    isRunning = false;
                }
                else
                {
                    handler.OnKeyPressed(key);
                }
            }

            Console.WriteLine("Program terminated.");
        }

        /// <summary>
        /// The program entry point.
        /// </summary>
        public static void Main()
        {
            Program program = new Program();
            program.Run();
        }
    }
}
