using FriendsApp.Models;
using FriendsApp.Services;

namespace FriendsApp
{
    /// <summary>
    /// Entry point of the Friends application.
    /// </summary>
    internal class Program
    {
        private const string InputFilePath = "friends.txt";
        private const string OutputDirectory = "Output";

        private void Run()
        {
            var service = new FriendsService();
            service.LoadFriends(InputFilePath);

            Console.WriteLine("Available Zodiac signs:");
            var signs = Enum.GetValues(typeof(ZodiacSign));
            int index = 1;
            foreach (ZodiacSign sign in signs)
            {
                Console.WriteLine($"{index}. {sign}");
                index++;
            }

            Console.Write("Select a Zodiac sign (number): ");
            if (!int.TryParse(Console.ReadLine(), out int signChoice) || signChoice < 1 || signChoice > signs.Length)
            {
                Console.WriteLine("Invalid input.");
                return;
            }
            var selectedSign = (ZodiacSign)signs.GetValue(signChoice - 1);

            Console.WriteLine("Select output format:");
            Console.WriteLine("1. Last name and age");
            Console.WriteLine("2. Last name, days until birthday and phone");

            if (!int.TryParse(Console.ReadLine(), out int formatChoice) || (formatChoice != 1 && formatChoice != 2))
            {
                Console.WriteLine("Invalid format selection.");
                return;
            }

            var friends = service.GetFriendsBySign(selectedSign);
            friends.Sort((a, b) => a.LastName.CompareTo(b.LastName));

            Console.WriteLine($"\nFound {friends.Count} friends:");
            foreach (var friend in friends)
            {
                Console.WriteLine(friend.GetInfo(formatChoice));
            }

            service.SaveFriendsBySignToFiles(OutputDirectory);
            Console.WriteLine($"\nData saved to '{OutputDirectory}' directory.");
        }

        /// <summary>
        /// Main method.
        /// </summary>
        private static void Main()
        {
            var program = new Program();
            program.Run();
        }
    }
}
