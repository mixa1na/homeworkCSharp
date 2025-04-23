/// <summary>
/// Extracts words from text before specified position
/// </summary>
public class WordExtractor
{
    /// <summary>
    /// Extracts words separated by spaces before given position
    /// </summary>
    public string ExtractBeforePosition(string text, int position)
    {
        if (string.IsNullOrWhiteSpace(text) || position <= 0)
        {
            return string.Empty;
        }

        var relevantText = text.Substring(0, position);
        var words = relevantText.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        return string.Join(' ', words);
    }
}