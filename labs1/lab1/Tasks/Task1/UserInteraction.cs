using System;
using System.Linq;

namespace Task1
{
    public class ConsoleInterface : IUserInterface
    {
        public int GetStrictlyPositiveInteger(string message)
        {
            while (true)
            {
                Console.Write($"{message} ");

                if (int.TryParse(Console.ReadLine(), out int value) && value > 0)
                {
                    return value;
                }
                Console.WriteLine("Size must be positive integer");
            }
        }

        public double[] GetDoubleArray(string message, int requiredSize)
        {
            Console.WriteLine($"{message} Enter exactly {requiredSize}");

            while (true)
            {
                try
                {
                    var input = Console.ReadLine()?.Trim();
                    if (string.IsNullOrEmpty(input))
                    {
                        Console.WriteLine("Input can not be empty");
                        continue;
                    }

                    var numbers = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                     .Select(double.Parse)
                                     .ToArray();

                    if (numbers.Length == requiredSize)
                    {
                        return numbers;
                    }

                    Console.WriteLine($"Enter exactly {requiredSize} numbers");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid number format");
                }
            }
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void ShowArray(string name, double[] array)
        {
            Console.WriteLine($"{name}: {string.Join(" ", array)}");
        }
    }
}