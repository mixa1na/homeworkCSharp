using System;

namespace PolygonProject.Shapes
{
    /// <summary>
    /// Represents a triangle polygon
    /// </summary>
    public class Triangle : Polygon
    {
        public Triangle(List<(int X, int Y)> points, string color)
        {
            Type = "Triangle";
            Points = points;
            Color = color;
        }

        /// <summary>
        /// Calculates the area of the triangle
        /// </summary>
        public override double GetArea()
        {
            double x1 = Points[0].X, y1 = Points[0].Y;
            double x2 = Points[1].X, y2 = Points[1].Y;
            double x3 = Points[2].X, y3 = Points[2].Y;
            return Math.Abs((x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2)) / 2.0);
        }

        /// <summary>
        /// Calculates the perimeter of the triangle
        /// </summary>
        public override double GetPerimeter()
        {
            double a = Distance(Points[0], Points[1]);
            double b = Distance(Points[1], Points[2]);
            double c = Distance(Points[2], Points[0]);
            return a + b + c;
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
