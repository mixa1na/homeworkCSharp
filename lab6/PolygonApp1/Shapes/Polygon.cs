namespace PolygonProject.Shapes
{
    /// <summary>
    /// Abstract base class for polygons
    /// </summary>
    public abstract class Polygon
    {
        public string Type { get; set; }
        public string Color { get; set; }
        public List<(int X, int Y)> Points { get; set; }

        /// <summary>
        /// Calculates the area of the polygon
        /// </summary>
        public abstract double GetArea();

        /// <summary>
        /// Calculates the perimeter of the polygon
        /// </summary>
        public abstract double GetPerimeter();

        /// <summary>
        /// Displays formatted polygon information
        /// </summary>
        public virtual void PrintInfo(int number)
        {
            Console.WriteLine($"{number}\t{Type}\t{GetPerimeter():F2}\t{GetArea():F2}\t{Color}");
        }
    }
}
