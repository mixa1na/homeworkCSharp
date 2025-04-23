using System.Text.RegularExpressions;

/// <summary>
/// Finds dates in text using regular expressions
/// </summary>
public class DateFinder
{
    private readonly Regex _datePattern;

    /// <summary>
    /// Initializes a new instance of the DateFinder class
    /// </summary>
    public DateFinder()
    {
        _datePattern = new Regex(
            @"\b\d{1,2}[/\-.]\d{1,2}[/\-.]\d{2,4}\b|\b(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)[a-z]* \d{1,2},? \d{4}\b",
            RegexOptions.IgnoreCase);
    }

    /// <summary>
    /// Finds position of date in text
    /// </summary>
    public int? FindDatePosition(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return null;
        }

        var match = _datePattern.Match(text);
        return match.Success ? match.Index : (int?)null;
    }
}