using PolygonApp.Models;
using PolygonApp.Services;

namespace PolygonApp
{
    /// <summary>
    /// Main application class for polygon processing
    /// </summary>
    static class Program
    {
        private const string FileName = "polygons.txt";
        private const string FileNotFoundMessage = "Error: File 'polygons.txt' not found in application directory";
        private const string FileInstructions = "Please ensure the file exists in the same folder as the executable";
        private const string NoPolygonsMessage = "No valid polygons found in the file";
        private const string FileFormatMessage = "File format should be:";
        private const string TriangleFormat = "triangle x1 y1 x2 y2 x3 y3 Color";
        private const string RectangleFormat = "rectangle x1 y1 x2 y2 Color";

        /// <summary>
        /// Application entry point
        /// </summary>
        static void Main()
        {
            try
            {
                string filePath = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    FileName);

                Console.WriteLine($"Looking for file at: {filePath}");

                if (!File.Exists(filePath))
                {
                    Console.WriteLine(FileNotFoundMessage);
                    Console.WriteLine(FileInstructions);
                    return;
                }

                var service = new PolygonDataService();

                var polygons = service.ReadPolygonsFromFile(filePath);
                if (polygons == null || polygons.Count == 0)
                {
                    Console.WriteLine(NoPolygonsMessage);
                    Console.WriteLine(FileFormatMessage);
                    Console.WriteLine(TriangleFormat);
                    Console.WriteLine(RectangleFormat);
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
            const string initialDataTitle = "Initial data:";
            const string sortedDataTitle = "\nSorted by area:";
            const string modifiedDataTitle = "\nAfter color modifications:";

            service.PrintPolygons(polygons, initialDataTitle);

            polygons.Sort(new PolygonAreaComparer());
            service.PrintPolygons(polygons, sortedDataTitle);

            ModifySpecialTriangles(polygons);
            service.PrintPolygons(polygons, modifiedDataTitle);
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