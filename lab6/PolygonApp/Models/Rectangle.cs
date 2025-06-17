namespace PolygonApp.Models
{
    /// <summary>
    /// Class representing a rectangle
    /// </summary>
    public class Rectangle : Polygon
    {
        private const int RequiredCoordinates = 4;
        private const int PerimeterMultiplier = 2;

        /// <summary>
        /// Initializes rectangle with two corner points
        /// </summary>
        public Rectangle(int x1, int y1, int x2, int y2, ConsoleColor color)
        {
            polygonType = "Rectangle";
            vertices = new int[] { x1, y1, x2, y2 };
            this.color = color;
        }

        /// <inheritdoc/>
        public override double CalculateArea()
        {
            int width = Math.Abs(vertices[2] - vertices[0]);
            int height = Math.Abs(vertices[3] - vertices[1]);
            return width * height;
        }

        /// <inheritdoc/>
        public override double CalculatePerimeter()
        {
            int width = Math.Abs(vertices[2] - vertices[0]);
            int height = Math.Abs(vertices[3] - vertices[1]);
            return PerimeterMultiplier * (width + height);
        }
    }
}