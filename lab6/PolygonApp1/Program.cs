
using PolygonProject.Shapes;
using PolygonProject.Utils;

namespace PolygonProject
{
    class Program
    {
        /// <summary>
        /// Main entry point: reads polygons, filters, sorts and displays them
        /// </summary>
        static void Main()
        {
            var lines = FileReader.Read("input.txt");
            var polygons = new List<Polygon>();

            foreach (var line in lines)
            {
                var polygon = PolygonFactory.CreatePolygon(line);
                if (polygon != null)
                {
                    if (polygon.Color == "White")
                        polygon.Color = "Red";

                    if (polygon.GetArea() > 10)
                        polygons.Add(polygon);
                }
            }

            polygons.Sort(new PolygonComparer());

            int count = 1;
            Console.WriteLine("No\tType\tPerimeter\tArea\tColor");
            foreach (var p in polygons)
            {
                p.PrintInfo(count);
                count++;
            }
        }
    }
}