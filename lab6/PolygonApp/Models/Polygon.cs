namespace PolygonApp.Models
{
    /// <summary>
    /// Abstract base class for all polygons
    /// </summary>
    public abstract class Polygon
    {
        /// <summary>
        /// Type of the polygon (e.g., "Triangle", "Rectangle")
        /// </summary>
        protected string polygonType;

        /// <summary>
        /// Array of vertex coordinates [x1,y1, x2,y2,...]
        /// </summary>
        protected int[] vertices;

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
            Console.ForegroundColor = color;
            Console.WriteLine($"{index}\t{polygonType}\t{CalculatePerimeter():F2}\t{CalculateArea():F2}\t{color}");
            Console.ResetColor();
        }
    }
}