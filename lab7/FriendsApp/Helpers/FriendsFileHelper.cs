using FriendsApp.Models;

namespace FriendsApp.Helpers
{
    /// <summary>
    /// Helper class for reading and writing friend data to files.
    /// </summary>
    public class FriendsFileHelper
    {
        /// <summary>
        /// Reads friends from file.
        /// </summary>
        public List<Friend> ReadFriendsFromFile(string filePath)
        {
            var friends = new List<Friend>();

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File not found: {filePath}");
                return friends;
            }

            var lines = File.ReadAllLines(filePath);

            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                var parts = line.Split(';');

                if (parts.Length != 4)
                {
                    Console.WriteLine($"Skipping line {i + 1}: Incorrect number of fields.");
                    continue;
                }

                var lastName = parts[0].Trim();
                var birthDateStr = parts[1].Trim();
                var signStr = parts[2].Trim();
                var phone = parts[3].Trim();

                if (!DateTime.TryParse(birthDateStr, out var birthDate))
                {
                    Console.WriteLine($"Skipping line {i + 1}: Invalid date format.");
                    continue;
                }

                if (!Enum.TryParse(signStr, out ZodiacSign sign))
                {
                    Console.WriteLine($"Skipping line {i + 1}: Invalid zodiac sign.");
                    continue;
                }

                friends.Add(new Friend
                {
                    LastName = lastName,
                    BirthDate = birthDate,
                    Sign = sign,
                    PhoneNumber = phone
                });
            }

            return friends;
        }

        /// <summary>
        /// Saves the list of friends to a text file named by the zodiac sign.
        /// </summary>
        public void SaveFriendsToFile(List<Friend> friends, ZodiacSign sign, string outputDirectory)
        {
            Directory.CreateDirectory(outputDirectory);

            string filePath = Path.Combine(outputDirectory, sign + ".txt");

            var lines = new List<string>();
            lines.Add(sign + ":");
            lines.Add("№\tLast name\tPhone\tDate of birth");

            for (int i = 0; i < friends.Count; i++)
            {
                Friend friend = friends[i];
                string line = (i + 1) + "\t" + friend.LastName + "\t" + friend.PhoneNumber + "\t" + friend.BirthDate.ToString("dd.MM.yy");
                lines.Add(line);
            }

            File.WriteAllLines(filePath, lines);
        }
    }
}