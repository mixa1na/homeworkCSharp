namespace PolygonApp.Models
{
    /// <summary>
    /// Class representing a triangle
    /// </summary>
    public class Triangle : Polygon
    {
        /// <summary>
        /// Initializes triangle with three vertex points
        /// </summary>
        public Triangle(int x1, int y1, int x2, int y2, int x3, int y3, ConsoleColor color)
        {
            polygonType = "Triangle";
            vertices = new int[] { x1, y1, x2, y2, x3, y3 };
            this.color = color;
        }

        /// <inheritdoc/>
        public override double CalculateArea()
        {
            return 0.5 * Math.Abs(
                (vertices[0] - vertices[4]) * (vertices[3] - vertices[1]) -
                (vertices[0] - vertices[2]) * (vertices[5] - vertices[1]));
        }

        /// <inheritdoc/>
        public override double CalculatePerimeter()
        {
            double side1 = Math.Sqrt(Math.Pow(vertices[2] - vertices[0], 2) + Math.Pow(vertices[3] - vertices[1], 2));
            double side2 = Math.Sqrt(Math.Pow(vertices[4] - vertices[2], 2) + Math.Pow(vertices[5] - vertices[3], 2));
            double side3 = Math.Sqrt(Math.Pow(vertices[4] - vertices[0], 2) + Math.Pow(vertices[5] - vertices[1], 2));
            return side1 + side2 + side3;
        }

        /// <summary>
        /// Checks if triangle is right-angled (with 1e-3 precision)
        /// </summary>
        public bool IsRightAngled()
        {
            double a2 = Math.Pow(vertices[2] - vertices[0], 2) + Math.Pow(vertices[3] - vertices[1], 2);
            double b2 = Math.Pow(vertices[4] - vertices[2], 2) + Math.Pow(vertices[5] - vertices[3], 2);
            double c2 = Math.Pow(vertices[4] - vertices[0], 2) + Math.Pow(vertices[5] - vertices[1], 2);

            return Math.Abs(a2 + b2 - c2) < 0.001 ||
                   Math.Abs(a2 + c2 - b2) < 0.001 ||
                   Math.Abs(b2 + c2 - a2) < 0.001;
        }

        /// <summary>
        /// Checks if all vertices are in II coordinate quadrant (x < 0, y > 0)
        /// </summary>
        public bool IsInSecondQuadrant()
        {
            for (int i = 0; i < vertices.Length; i += 2)
            {
                if (vertices[i] >= 0 || vertices[i + 1] <= 0)
                    return false;
            }
            return true;
        }
    }
}