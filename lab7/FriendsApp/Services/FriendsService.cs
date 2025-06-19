using FriendsApp.Helpers;
using FriendsApp.Models;

namespace FriendsApp.Services
{
    /// <summary>
    /// Service class for managing friends.
    /// </summary>
    public class FriendsService
    {
        private readonly FriendsFileHelper _fileHelper = new FriendsFileHelper();

        /// <summary>
        /// All loaded friends.
        /// </summary>
        public List<Friend> Friends { get; private set; } = new List<Friend>();

        /// <summary>
        /// Loads friends from a file.
        /// </summary>
        public void LoadFriends(string filePath)
        {
            Friends = _fileHelper.ReadFriendsFromFile(filePath);
        }

        /// <summary>
        /// Returns friends by selected Zodiac sign.
        /// </summary>
        public List<Friend> GetFriendsBySign(ZodiacSign sign)
        {
            return Friends
                .Where(f => f.Sign == sign)
                .OrderBy(f => f.LastName)
                .ToList();
        }

        /// <summary>
        /// Saves all friends sorted by sign to separate files.
        /// </summary>
        public void SaveFriendsBySignToFiles(string outputDirectory)
        {
            var uniqueSigns = Friends.Select(f => f.Sign).Distinct();

            foreach (var sign in uniqueSigns)
            {
                var friendsForSign = GetFriendsBySign(sign);
                _fileHelper.SaveFriendsToFile(friendsForSign, sign, outputDirectory);
            }
        }
    }
}
