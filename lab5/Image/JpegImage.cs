namespace Image;

/// <summary>
/// Represents a JPEG image.
/// </summary>
public class JpegImage : Image
{
    /// <inheritdoc/>
    public override void Display()
    {
        if (string.IsNullOrWhiteSpace(FileName))
            throw new InvalidOperationException("JPEG image must have a valid FileName.");
        if (Size <= 0)
            throw new InvalidOperationException("JPEG image must have a valid Size.");

        Console.WriteLine("Displaying JPEG image");
    }
}
