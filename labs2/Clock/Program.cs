using System;

namespace Clock
{
    class Program
    {
        static void Main(string[] args)
        {
            Clock clock = new Clock(0, 0, 0);
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine($"Current time: {clock.GetTime()}");
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Set time manually");
                Console.WriteLine("2. Add seconds");
                Console.WriteLine("3. Exit");
                Console.Write("Select option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        SetTimeManually(clock);
                        break;

                    case "2":
                        AddSecondsToClock(clock);
                        break;

                    case "3":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option!");
                        break;
                }

                if (running)
                {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        private static void SetTimeManually(Clock clock)
        {
            Console.Write("Enter hours (0-23): ");
            int h = int.Parse(Console.ReadLine());
            Console.Write("Enter minutes (0-59): ");
            int m = int.Parse(Console.ReadLine());
            Console.Write("Enter seconds (0-59): ");
            int s = int.Parse(Console.ReadLine());
            clock.SetTime(h, m, s);
            Console.WriteLine("Time set successfully!");
        }

        private static void AddSecondsToClock(Clock clock)
        {
            Console.Write("Enter seconds to add: ");
            int sec = int.Parse(Console.ReadLine());
            clock.AddSeconds(sec);
            Console.WriteLine($"Added {sec} seconds");
        }
    }
}