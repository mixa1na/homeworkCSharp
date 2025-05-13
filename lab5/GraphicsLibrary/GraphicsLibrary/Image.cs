using System;

namespace GraphicsProject.GraphicsLibrary
{
    /// <summary>
    /// Abstract base class representing an image with common properties and methods.
    /// </summary>
    public abstract class Image
    {
        private readonly string _fileName;
        private int _size;

        /// <summary>
        /// Initializes a new instance of the Image class.
        /// </summary>
        protected Image(string fileName, int size)
        {
            _fileName = fileName;
            Size = size;
        }

        /// <summary>
        /// Gets the name of the image file.
        /// </summary>
        public string FileName => _fileName;

        /// <summary>
        /// Gets or sets the size of the image in kilobytes.
        /// </summary>
        public int Size
        {
            get => _size;
            private set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "Size must be positive");
                _size = value;
            }
        }

        /// <summary>
        /// Changes the size of the image.
        /// </summary>
        public void ChangeSize(int newSize) => Size = newSize;

        /// <summary>
        /// Displays the image (implementation specific to each format).
        /// </summary>
        public abstract void Display();
    }
}