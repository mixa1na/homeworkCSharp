using System;

namespace FriendsApp.Models
{
    /// <summary>
    /// Represents a friend with personal information.
    /// </summary>
    public struct Friend
    {
        /// <summary>
        /// Last name with initials.
        /// </summary>
        public string LastName;

        /// <summary>
        /// Date of birth.
        /// </summary>
        public DateTime BirthDate;

        /// <summary>
        /// Zodiac sign.
        /// </summary>
        public ZodiacSign Sign;

        /// <summary>
        /// Phone number.
        /// </summary>
        public string PhoneNumber;

        /// <summary>
        /// Gets the age of the friend.
        /// </summary>
        public int Age
        {
            get
            {
                var today = DateTime.Today;
                int age = today.Year - BirthDate.Year;
                if (BirthDate > today.AddYears(-age))
                {
                    age--;
                }
                return age;
            }
        }

        /// <summary>
        /// Gets number of days until the next birthday.
        /// </summary>
        public int DaysUntilBirthday
        {
            get
            {
                var today = DateTime.Today;
                var nextBirthday = new DateTime(today.Year, BirthDate.Month, BirthDate.Day);

                if (nextBirthday < today)
                {
                    nextBirthday = nextBirthday.AddYears(1);
                }

                return (nextBirthday - today).Days;
            }
        }
        public const int FormatLastNameAndAge = 1;
        public const int FormatLastNameDaysPhone = 2;

        /// <summary>
        /// Returns string with information depending on selected format.
        /// </summary>
        public string GetInfo(int format)
        {

            if (format == FormatLastNameAndAge)
            {
                return $"{LastName}, {Age} years";
            }
            else if (format == FormatLastNameDaysPhone)
            {
                return $"{LastName}, {DaysUntilBirthday} days until birthday, {PhoneNumber}";
            }
            else
            {
                return $"{LastName} | {BirthDate:dd.mm.yyyy} | {Sign} | {PhoneNumber}";
            }
        }
    }
}