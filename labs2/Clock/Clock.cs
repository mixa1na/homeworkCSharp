public class Clock
{
    private readonly TimeData _time = new TimeData();

    public Clock(int hours, int minutes, int seconds)
    {
        SetTime(hours, minutes, seconds);
    }

    public void SetTime(int hours, int minutes, int seconds)
    {
        if (hours > 23 || minutes > 59 || seconds > 59 ||
            hours < 0 || minutes < 0 || seconds < 0)
        {
            _time.Hours = 23;
            _time.Minutes = 59;
            _time.Seconds = 59;
        }
        else
        {
            _time.Hours = hours;
            _time.Minutes = minutes;
            _time.Seconds = seconds;
        }
    }

    public string GetTime()
    {
        return $"{_time.Hours:D2}:{_time.Minutes:D2}:{_time.Seconds:D2}";
    }

    public void AddSeconds(int seconds)
    {
        if (seconds < 0) return;

        int total = _time.Hours * 3600 + _time.Minutes * 60 + _time.Seconds + seconds;
        total %= 86400;

        _time.Hours = total / 3600;
        _time.Minutes = (total % 3600) / 60;
        _time.Seconds = total % 60;
    }
}