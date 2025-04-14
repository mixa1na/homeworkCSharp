namespace Clock
{
    public class TimeData
    {
        private int _hours;
        private int _minutes;
        private int _seconds;

        public int Hours
        {
            get => _hours;
            set => _hours = ValidateHours(value);
        }

        public int Minutes
        {
            get => _minutes;
            set => _minutes = ValidateMinutes(value);
        }

        public int Seconds
        {
            get => _seconds;
            set => _seconds = ValidateSeconds(value);
        }

        private int ValidateHours(int value) => value < 0 ? 0 : value > 23 ? 23 : value;
        private int ValidateMinutes(int value) => value < 0 ? 0 : value > 59 ? 59 : value;
        private int ValidateSeconds(int value) => value < 0 ? 0 : value > 59 ? 59 : value;
    }
}