namespace Clock
{
    public class Clock
    {
        private readonly TimeData _time = new TimeData();

        public int Hours
        {
            get => _time.Hours;
            set => _time.Hours = value;
        }

        public int Minutes
        {
            get => _time.Minutes;
            set => _time.Minutes = value;
        }

        public int Seconds
        {
            get => _time.Seconds;
            set => _time.Seconds = value;
        }

        public Clock(int hours, int minutes, int seconds)
        {
            SetTime(hours, minutes, seconds);
        }

        public void SetTime(int hours, int minutes, int seconds)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }

        public string GetTime()
        {
            return $"{Hours:D2}:{Minutes:D2}:{Seconds:D2}";
        }

        public void AddSeconds(int seconds)
        {
            if (seconds < 0) return;

            int totalSeconds = Hours * 3600 + Minutes * 60 + Seconds + seconds;
            totalSeconds %= 86400;

            Hours = totalSeconds / 3600;
            Minutes = (totalSeconds % 3600) / 60;
            Seconds = totalSeconds % 60;
        }
    }
}