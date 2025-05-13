using System;
using GraphicsProject.GraphicsLibrary;

namespace GraphicsProject.GraphicsLibrary.ImageFormat
{
    /// <summary>
    /// Represents an image in JPEG format.
    /// </summary>
    public class JpegImage : Image
    {
        /// <inheritdoc/>
        public JpegImage(string fileName, int size) : base(fileName, size)
        {
        }

        /// <inheritdoc/>
        public override void Display()
        {
            Console.WriteLine("Отображение jpeg изображения");
        }
    }
}