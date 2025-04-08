public class TimeData
{
    private int _hours;
    private int _minutes;
    private int _seconds;

    public int Hours
    {
        get => _hours;
        set => _hours = value < 0 ? 0 : value > 23 ? 23 : value;
    }

    public int Minutes
    {
        get => _minutes;
        set => _minutes = value < 0 ? 0 : value > 59 ? 59 : value;
    }

    public int Seconds
    {
        get => _seconds;
        set => _seconds = value < 0 ? 0 : value > 59 ? 59 : value;
    }
}