using PolygonProject.Shapes;

namespace PolygonProject.Utils
{
    /// <summary>
    /// Factory class for creating Polygon instances from input strings
    /// </summary>
    public class PolygonFactory
    {
        public static Polygon? CreatePolygon(string line)
        {
            var parts = line.Split(' ');
            if (parts.Length < 2) return null;

            var type = parts[0].ToLower();
            var numbers = parts.Skip(1).Take(parts.Length - 2).Select(int.Parse).ToList();
            var color = parts.Last();

            var points = new List<(int X, int Y)>();
            for (int i = 0; i < numbers.Count; i += 2)
                points.Add((numbers[i], numbers[i + 1]));

            return type switch
            {
                "треугольник" => new Triangle(points, color),
                "прямоугольник" => new Rectangle(points, color),
                _ => null
            };
        }
    }
}