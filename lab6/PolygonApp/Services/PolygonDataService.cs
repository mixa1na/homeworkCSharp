using PolygonApp.Models;

namespace PolygonApp.Services
{
    /// <summary>
    /// Service for reading and processing polygon data from files
    /// </summary>
    public class PolygonDataService
    {
        private const int MinPartsLength = 6;
        private const int TriangleCoordCount = 6;
        private const int RectangleCoordCount = 4;

        /// <summary>
        /// Reads polygons from specified text file
        /// </summary>
        public List<Polygon> ReadPolygonsFromFile(string filePath)
        {
            var polygons = new List<Polygon>();

            if (!File.Exists(filePath))
            {
                return polygons;
            }

            foreach (var line in File.ReadAllLines(filePath))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length < MinPartsLength) continue;

                try
                {
                    var color = ParseColor(parts.Last());
                    var coords = parts.Skip(1).Take(parts.Length - 2).Select(int.Parse).ToArray();

                    if (parts[0].Equals("triangle", StringComparison.OrdinalIgnoreCase) && coords.Length == TriangleCoordCount)
                    {
                        polygons.Add(new Triangle(
                            coords[0], coords[1],
                            coords[2], coords[3],
                            coords[4], coords[5],
                            color));
                    }
                    else if (parts[0].Equals("rectangle", StringComparison.OrdinalIgnoreCase) && coords.Length == RectangleCoordCount)
                    {
                        polygons.Add(new Rectangle(
                            coords[0], coords[1],
                            coords[2], coords[3],
                            color));
                    }
                }
                catch
                {
                    continue;
                }
            }

            return polygons;
        }

        /// <summary>
        /// Parses string representation of color to ConsoleColor
        /// </summary>
        private ConsoleColor ParseColor(string colorStr)
        {
            return Enum.TryParse(colorStr, true, out ConsoleColor color)
                ? color
                : ConsoleColor.White;
        }

        /// <summary>
        /// Prints polygons information to console
        /// </summary>
        public void PrintPolygons(List<Polygon> polygons, string title)
        {
            const string header = "№\tType\t\tPerimeter\tArea\tColor";

            Console.WriteLine(title);
            Console.WriteLine(header);

            for (int i = 0; i < polygons.Count; i++)
            {
                polygons[i].PrintInfo(i + 1);
            }
        }
    }
}