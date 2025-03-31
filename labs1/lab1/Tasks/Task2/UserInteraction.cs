using System;
using System.Globalization;
using System.Linq;

namespace Task2
{
    class ConsoleInterface : IUserInterface
    {
        public int GetIntegerInput(string message)
        {
            Console.Write(message + " ");
            int value;
            while (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Invalid input. Please enter integer.");
            }
            return value;
        }

        public double GetDoubleInput(string message)
        {
            Console.Write(message + " ");
            double value;
            while (true)
            {
                string input = Console.ReadLine().Replace(",", ".");
                if (double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out value))
                {
                    return value;
                }
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }

        public double[] GetDoubleArray(string message)
        {
            Console.Write(message + " ");
            double[] array;
            while (true)
            {
                try
                {
                    array = Console.ReadLine()
                        .Replace(",", ".")
                        .Split(' ')
                        .Select(x => double.Parse(x, CultureInfo.InvariantCulture))
                        .ToArray();
                    break;
                }
                catch
                {
                    Console.WriteLine("Invalid input. Please enter numbers separated by spaces.");
                }
            }
            return array;
        }

        public string GetStringInput(string message)
        {
            Console.Write(message + " ");
            return Console.ReadLine().Trim();
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
