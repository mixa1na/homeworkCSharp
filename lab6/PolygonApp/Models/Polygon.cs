namespace PolygonApp.Models
{
    /// <summary>
    /// Abstract base class for all polygons
    /// </summary>
    public abstract class Polygon
    {
        protected const int CoordinatesPerVertex = 2;

        /// <summary>
        /// Type of the polygon (e.g., "Triangle", "Rectangle")
        /// </summary>
        protected string polygonType = string.Empty;

        /// <summary>
        /// Array of vertex coordinates [x1,y1, x2,y2,...]
        /// </summary>
        protected int[] vertices = Array.Empty<int>();

        /// <summary>
        /// Color for console output
        /// </summary>
        protected ConsoleColor color;

        /// <summary>
        /// Calculates area of the polygon
        /// </summary>
        public abstract double CalculateArea();

        /// <summary>
        /// Calculates perimeter of the polygon
        /// </summary>
        public abstract double CalculatePerimeter();

        /// <summary>
        /// Prints polygon info to console in required format
        /// </summary>
        public virtual void PrintInfo(int index)
        {
            const string formatString = "{0}\t{1}\t{2:F2}\t{3:F2}\t{4}";
            Console.ForegroundColor = color;
            Console.WriteLine(formatString, index, polygonType, CalculatePerimeter(), CalculateArea(), color);
            Console.ResetColor();
        }
    }
}