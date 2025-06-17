using PolygonApp.Models;

namespace PolygonApp.Services
{
    /// <summary>
    /// Service for reading and processing polygon data from files
    /// </summary>
    public class PolygonDataService
    {
        /// <summary>
        /// Reads polygons from specified text file
        /// </summary>
        /// <param name="filePath">Path to the input file</param>
        /// <returns>List of parsed polygons or empty list if file not found</returns>
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
                if (parts.Length < 6) continue;

                try
                {
                    var color = ParseColor(parts.Last());
                    var coords = parts.Skip(1).Take(parts.Length - 2).Select(int.Parse).ToArray();

                    if (parts[0].Equals("triangle", StringComparison.OrdinalIgnoreCase) && coords.Length == 6)
                    {
                        polygons.Add(new Triangle(
                            coords[0], coords[1],
                            coords[2], coords[3],
                            coords[4], coords[5],
                            color));
                    }
                    else if (parts[0].Equals("rectangle", StringComparison.OrdinalIgnoreCase) && coords.Length == 4)
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
            Console.WriteLine(title);
            Console.WriteLine("№\tType\t\tPerimeter\tArea\tColor");

            for (int i = 0; i < polygons.Count; i++)
            {
                polygons[i].PrintInfo(i + 1);
            }
        }
    }
}