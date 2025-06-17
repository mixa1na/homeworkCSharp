using System.Collections.Generic;

namespace PolygonApp.Models
{
    /// <summary>
    /// Compares polygons by their area for sorting
    /// </summary>
    public class PolygonAreaComparer : IComparer<Polygon>
    {
        /// <summary>
        /// Compares two polygons by calculated area
        /// </summary>
        public int Compare(Polygon x, Polygon y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            return x.CalculateArea().CompareTo(y.CalculateArea());
        }
    }
}