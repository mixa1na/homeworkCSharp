using PolygonApp.Models;
using PolygonApp.Services;

namespace PolygonApp
{
    /// <summary>
    /// Main application class for polygon processing
    /// </summary>
    class Program
    {
        /// <summary>
        /// Application entry point
        /// </summary>
        static void Main()
        {
            try
            {
                string filePath = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "polygons.txt");

                Console.WriteLine($"Looking for file at: {filePath}");

                if (!File.Exists(filePath))
                {
                    Console.WriteLine("Error: File 'polygons.txt' not found in application directory");
                    Console.WriteLine("Please ensure the file exists in the same folder as the executable");
                    return;
                }

                var service = new PolygonDataService();

                var polygons = service.ReadPolygonsFromFile(filePath);
                if (polygons == null || polygons.Count == 0)
                {
                    Console.WriteLine("No valid polygons found in the file");
                    Console.WriteLine("File format should be:");
                    Console.WriteLine("triangle x1 y1 x2 y2 x3 y3 Color");
                    Console.WriteLine("rectangle x1 y1 x2 y2 Color");
                    return;
                }

                ProcessPolygons(service, polygons);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("\nPress any key to exit...");
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Executes all required polygon processing steps
        /// </summary>
        private static void ProcessPolygons(PolygonDataService service, List<Polygon> polygons)
        {
            service.PrintPolygons(polygons, "Initial data:");

            polygons.Sort(new PolygonAreaComparer());
            service.PrintPolygons(polygons, "\nSorted by area:");

            ModifySpecialTriangles(polygons);
            service.PrintPolygons(polygons, "\nAfter color modifications:");
        }

        /// <summary>
        /// Changes color of right-angled triangles in second quadrant to Green
        /// </summary>
        private static void ModifySpecialTriangles(List<Polygon> polygons)
        {
            int modifiedCount = 0;

            foreach (var polygon in polygons)
            {
                if (polygon is Triangle triangle &&
                    triangle.IsRightAngled() &&
                    triangle.IsInSecondQuadrant())
                {
                    var colorField = typeof(Polygon).GetField("color",
                        System.Reflection.BindingFlags.NonPublic |
                        System.Reflection.BindingFlags.Instance);

                    colorField?.SetValue(polygon, ConsoleColor.Green);
                    modifiedCount++;
                }
            }

            Console.WriteLine($"\nModified {modifiedCount} triangles");
        }
    }
}