using System;
using GraphicsProject.GraphicsLibrary;

namespace GraphicsProject.GraphicsLibrary.ImageFormat
{
    /// <summary>
    /// Represents an image in PNG format.
    /// </summary>
    public class PngImage : Image
    {
        /// <inheritdoc/>
        public PngImage(string fileName, int size) : base(fileName, size)
        {
        }

        /// <inheritdoc/>
        public override void Display()
        {
            Console.WriteLine("Отображение png изображения");
        }
    }
}