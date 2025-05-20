namespace Image
{
    /// <summary>
    /// Abstract base class representing a generic image.
    /// </summary>
    public abstract class Image
    {
        private string _fileName = string.Empty;
        private int _size;

        /// <summary>
        /// Gets or sets the file name of the image.
        /// </summary>
        public string FileName
        {
            get => _fileName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("FileName cannot be null or empty.");
                }

                _fileName = value;
            }
        }

        /// <summary>
        /// Gets the current size of the image.
        /// </summary>
        public int Size => _size;

        /// <summary>
        /// Sets the image size.
        /// </summary>
        public void SetSize(int newSize)
        {
            if (newSize <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(newSize), "Size must be greater than zero.");
            }

            _size = newSize;
        }

        /// <summary>
        /// Displays the image. Must be implemented by derived classes.
        /// </summary>
        public abstract void Display();
    }
}
