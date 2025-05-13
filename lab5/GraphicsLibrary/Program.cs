пusing GraphicsLibrary;
using GraphicsLibrary.ImageFormats;

/// <summary>
/// Demonstration program for image handling.
/// </summary>
class Program
{
    /// <summary>
    /// Entry point of the application.
    /// </summary>
    static void Main()
    {
        var images = new Image[]
        {
            new JpegImage("photo.jpg", 1024),
            new PngImage("diagram.png", 512)
        };

        foreach (var image in images)
        {
            image.Display();
            image.ChangeSize(image.Size + 100);
        }
    }
}