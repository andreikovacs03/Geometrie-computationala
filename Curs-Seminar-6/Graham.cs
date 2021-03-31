using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curs_Seminar_6
{
    class Graham
    {
        public static List<Point> ConvexHull(List<Point> p)
        {
            if (p.Count == 0) return new List<Point>();
            p = p.OrderBy(p => p.X).ToList();
            List<Point> h = new List<Point>();

            // lower hull
            foreach (var pt in p)
            {
                while (h.Count >= 2 && !Ccw(h[h.Count - 2], h[h.Count - 1], pt))
                {
                    h.RemoveAt(h.Count - 1);
                }
                h.Add(pt);
            }

            // upper hull
            int t = h.Count + 1;
            for (int i = p.Count - 1; i >= 0; i--)
            {
                Point pt = p[i];
                while (h.Count >= t && !Ccw(h[h.Count - 2], h[h.Count - 1], pt))
                {
                    h.RemoveAt(h.Count - 1);
                }
                h.Add(pt);
            }

            h.RemoveAt(h.Count - 1);
            return h;
        }

        private static bool Ccw(Point a, Point b, Point c)
        {
            return ((b.X - a.X) * (c.Y - a.Y)) > ((b.Y - a.Y) * (c.X - a.X));
        }
    }
}
