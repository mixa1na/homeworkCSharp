using PolygonProject.Shapes;

namespace PolygonProject.Utils
{
    /// <summary>
    /// Compares two polygons based on their area
    /// </summary>
    public class PolygonComparer : IComparer<Polygon>
    {
        public int Compare(Polygon? x, Polygon? y)
        {
            if (x == null || y == null) return 0;
            return x.GetArea().CompareTo(y.GetArea());
        }
    }
}