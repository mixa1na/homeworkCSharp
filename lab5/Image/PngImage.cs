namespace Image;

/// <summary>
/// Represents a PNG image.
/// </summary>
public class PngImage : Image
{
    /// <inheritdoc/>
    public override void Display()
    {
        if (string.IsNullOrWhiteSpace(FileName))
            throw new InvalidOperationException("PNG image must have a valid FileName.");
        if (Size <= 0)
            throw new InvalidOperationException("PNG image must have a valid Size.");

        Console.WriteLine("Displaying PNG image");
    }
}
