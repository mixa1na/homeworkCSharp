using System;

namespace PolygonProject.Shapes
{
    /// <summary>
    /// Represents a rectangle polygon
    /// </summary>
    public class Rectangle : Polygon
    {
        public Rectangle(List<(int X, int Y)> points, string color)
        {
            Type = "Rectangle";
            Points = points;
            Color = color;
        }

        /// <summary>
        /// Calculates the area of the rectangle
        /// </summary>
        public override double GetArea()
        {
            double width = Distance(Points[0], Points[1]);
            double height = Distance(Points[1], Points[2]);
            return width * height;
        }

        /// <summary>
        /// Calculates the perimeter of the rectangle
        /// </summary>
        public override double GetPerimeter()
        {
            double width = Distance(Points[0], Points[1]);
            double height = Distance(Points[1], Points[2]);
            return 2 * (width + height);
        }

        /// <summary>
        /// Calculates the distance between two points
        /// </summary>
        private double Distance((int X, int Y) p1, (int X, int Y) p2)
        {
            return Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
        }
    }
}
