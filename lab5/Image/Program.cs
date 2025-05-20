namespace Image;

/// <summary>
/// The main entry point of the application.
/// </summary>
internal class Program
{
    /// <summary>
    /// Demonstrates the creation and display of JPEG and PNG images.
    /// </summary>
    private static void Main()
    {
        try
        {
            Image jpeg = new JpegImage
            {
                FileName = "photo.jpeg"
            };
            jpeg.SetSize(1200);
            jpeg.Display();

            Image png = new PngImage
            {
                FileName = "icon.png"
            };
            png.SetSize(800);
            png.Display();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
