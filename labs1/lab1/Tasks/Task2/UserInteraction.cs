using System;
using System.Globalization;
using System.Linq;

namespace Task2
{
    public class ConsoleInterface : IUserInterface
    {
        public int GetStrictlyPositiveInteger(string message)
        {
            Console.Write(message);
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int value) && value > 0)
                {
                    return value;
                }
                Console.WriteLine("Must be positive integer");
            }
        }

        public double GetDouble(string message)
        {
            Console.Write(message);
            while (true)
            {
                var input = Console.ReadLine()?.Replace(",", ".");
                if (double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out double value))
                {
                    return value;
                }
                Console.WriteLine("Invalid number format");
            }
        }

        public double[] GetDoubleArray(string message)
        {
            Console.Write(message);
            while (true)
            {
                try
                {
                    var input = Console.ReadLine()?.Replace(",", ".");
                    var array = input?
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => double.Parse(x, CultureInfo.InvariantCulture))
                        .ToArray();

                    if (array?.Length > 0)
                    {
                        return array;
                    }

                    Console.WriteLine("At least 1 result required");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid number format");
                }
            }
        }

        public string GetNonEmptyString(string message)
        {
            Console.Write(message);
            while (true)
            {
                var input = Console.ReadLine()?.Trim();
                if (!string.IsNullOrEmpty(input))
                {
                    return input;
                }
                Console.WriteLine("Input cannot be empty");
            }
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}