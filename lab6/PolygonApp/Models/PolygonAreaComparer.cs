using System.Collections.Generic;

namespace PolygonApp.Models
{
    /// <summary>
    /// Compares polygons by their area for sorting
    /// </summary>
    public class PolygonAreaComparer : IComparer<Polygon?>
    {
        /// <summary>
        /// Compares two polygons by calculated area
        /// </summary>
        public int Compare(Polygon? x, Polygon? y)
        {
            const int equal = 0;
            const int xLessThanY = -1;
            const int yLessThanX = 1;

            if (x == null && y == null) return equal;
            if (x == null) return xLessThanY;
            if (y == null) return yLessThanX;

            return x.CalculateArea().CompareTo(y.CalculateArea());
        }
    }
}