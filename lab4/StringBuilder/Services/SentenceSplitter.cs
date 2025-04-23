/// <summary>
/// Splits text into sentences
/// </summary>
public class SentenceSplitter
{
    /// <summary>
    /// Splits text by periods and trims results
    /// </summary>
    public string[] Split(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return Array.Empty<string>();
        }

        return text.Split('.', StringSplitOptions.RemoveEmptyEntries)
                 .Select(s => s.Trim())
                 .Where(s => !string.IsNullOrEmpty(s))
                 .ToArray();
    }
}