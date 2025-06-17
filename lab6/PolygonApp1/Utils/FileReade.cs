namespace PolygonProject.Utils
{
    /// <summary>
    /// Utility class for reading lines from a file
    /// </summary>
    public class FileReader
    {
        public static List<string> Read(string path)
        {
            return File.ReadAllLines(path).ToList();
        }
    }
}