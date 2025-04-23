using System.Text;

/// <summary>
/// Main text processing logic
/// </summary>
public class TextProcessor
{
    private readonly SentenceSplitter _sentenceSplitter;
    private readonly DateFinder _dateFinder;
    private readonly WordExtractor _wordExtractor;

    /// <summary>
    /// Initializes a new instance with default dependencies
    /// </summary>
    public TextProcessor()
    {
        _sentenceSplitter = new SentenceSplitter();
        _dateFinder = new DateFinder();
        _wordExtractor = new WordExtractor();
    }

    /// <summary>
    /// Constructor for custom dependencies
    /// </summary>
    public TextProcessor(
        SentenceSplitter sentenceSplitter,
        DateFinder dateFinder,
        WordExtractor wordExtractor)
    {
        _sentenceSplitter = sentenceSplitter;
        _dateFinder = dateFinder;
        _wordExtractor = wordExtractor;
    }

    /// <summary>
    /// Processes input text according to business rules
    /// </summary>
    public StringBuilder Process(string inputText)
    {
        var result = new StringBuilder();

        if (string.IsNullOrWhiteSpace(inputText))
        {
            return result;
        }

        var sentences = _sentenceSplitter.Split(inputText);

        foreach (var sentence in sentences)
        {
            ProcessSentence(sentence, result);
        }

        return result;
    }

    // <summary>
    /// Processes individual sentence and appends results to StringBuilder
    /// </summary>
    private void ProcessSentence(string sentence, StringBuilder result)
    {
        var datePosition = _dateFinder.FindDatePosition(sentence);
        if (!datePosition.HasValue)
        {
            return;
        }

        var words = _wordExtractor.ExtractBeforePosition(sentence, datePosition.Value);
        if (words.Length == 0)
        {
            return;
        }

        if (result.Length > 0)
        {
            result.Append(' ');
        }

        result.Append(words);
    }
}