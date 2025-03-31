namespace Task1
{
    class ConsoleInterface : IUserInterface
    {
        public int GetIntegerInput(string message)
        {
            Console.Write(message + " ");
            int value;
            while (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Invalid input. Please enter an integer.");
            }
            return value;
        }

        public double[] GetDoubleArray(string message, int expectedSize)
        {
            Console.Write(message + " ");
            double[] array;
            while (true)
            {
                try
                {
                    array = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
                    if (array.Length != expectedSize)
                    {
                        throw new Exception($"Expected {expectedSize} elements.");
                    }
                    break;
                }
                catch
                {
                    Console.WriteLine("Invalid input. Please enter the correct size.");
                }
            }
            return array;
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void ShowArray(string name, double[] array)
        {
            Console.WriteLine($"{name}: " + string.Join(", ", array));
        }
    }
}
