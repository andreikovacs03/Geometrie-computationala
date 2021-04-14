using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Linq;
using System.Threading;

namespace QuickHull
{
    public class DivideAndConquer
    {
        static PointF mid = new PointF();
        static Random rng = new Random();
        public static List<PointF> ConvexHull(List<PointF> points)
        {
            if (points.Count <= 5)
            {
                var result2 = BruteHull(points);
                return result2;
            }

            List<PointF> left = new List<PointF>();
            List<PointF> right = new List<PointF>();

            for (int i = 0; i < points.Count / 2; i++)
                left.Add(points[i]);

            for (int i = points.Count() / 2; i < points.Count; i++)
                right.Add(points[i]);

            left = ConvexHull(left);
            right = ConvexHull(right);

            var result = MergeHull(left, right);
            QuickHullGraphics.Gfx.DrawPolygon(new Pen(Color.FromArgb(rng.Next(255), rng.Next(255), rng.Next(255)), 2), result.ToArray());
            Thread.Sleep(1000);
            return result;
        }

        public static List<PointF> MergeHull(List<PointF> a, List<PointF> b)
        {
            int n1 = a.Count, n2 = b.Count;

            int ia = 0, ib = 0;
            for (int i = 1; i < n1; i++)
                if (a[i].X > a[ia].X)
                    ia = i;

            for (int i = 1; i < n2; i++)
                if (b[i].X < b[ib].X)
                    ib = i;

            int inda = ia, indb = ib;
            bool done = false;
            while (!done)
            {
                done = true;
                while (Orientation(b[indb], a[inda], a[(inda + 1) % n1]) >= 0)
                    inda = (inda + 1) % n1;

                while (Orientation(a[inda], b[indb], b[(n2 + indb - 1) % n2]) <= 0)
                {
                    indb = (n2 + indb - 1) % n2;
                    done = false;
                }
            }

            int uppera = inda, upperb = indb;
            inda = ia;
            indb = ib;
            done = false;
            int g = 0;
            while (!done)
            {
                done = true;
                while (Orientation(a[inda], b[indb], b[(indb + 1) % n2]) >= 0)
                    indb = (indb + 1) % n2;

                while (Orientation(b[indb], a[inda], a[(n1 + inda - 1) % n1]) <= 0)
                {
                    inda = (n1 + inda - 1) % n1;
                    done = false;
                }
            }

            int lowera = inda, lowerb = indb;
            List<PointF> ret = new List<PointF>();

            int ind = uppera;
            ret.Add(a[uppera]);
            while (ind != lowera)
            {
                ind = (ind + 1) % n1;
                ret.Add(a[ind]);
            }

            ind = lowerb;
            ret.Add(b[lowerb]);
            while (ind != upperb)
            {
                ind = (ind + 1) % n2;
                ret.Add(b[ind]);
            }
            return ret;
        }

        public static List<PointF> BruteHull(List<PointF> points)
        {
            List<PointF> S = new List<PointF>();

            for (int i = 0; i < points.Count; i++)
                for (int j = i + 1; j < points.Count; j++)
                {
                    float x1 = points[i].X, x2 = points[j].X;
                    float y1 = points[i].Y, y2 = points[j].Y;

                    float a1 = y1 - y2;
                    float b1 = x2 - x1;
                    float c1 = x1 * y2 - y1 * x2;
                    int pos = 0, neg = 0;

                    for (int k = 0; k < points.Count; k++)
                    {
                        if (a1 * points[k].X + b1 * points[k].Y + c1 <= 0)
                            neg++;
                        if (a1 * points[k].X + b1 * points[k].Y + c1 >= 0)
                            pos++;
                    }
                    if (pos == points.Count || neg == points.Count)
                    {
                        S.Add(points[i]);
                        S.Add(points[j]);
                    }
                }

            List<PointF> ret = new List<PointF>();

            foreach (var e in S)
                ret.Add(e);

            mid = new PointF(0, 0);
            int n = ret.Count;

            for (int i = 0; i < n; i++)
            {
                mid.X += ret[i].X;
                mid.Y += ret[i].Y;
                ret[i] = new PointF(ret[i].X * n, ret[i].Y * n);
            }

            PointFComparer comp = new PointFComparer();
            ret.Sort(comp);

            for (int i = 0; i < n; i++)
                ret[i] = new PointF(ret[i].X / n, ret[i].Y / n);

            return ret;
        }

        static int Quad(PointF p)
        {
            if (p.X >= 0 && p.Y >= 0)
                return 1;
            if (p.X <= 0 && p.Y >= 0)
                return 2;
            if (p.X <= 0 && p.Y <= 0)
                return 3;
            return 4;
        }

        static int Orientation(PointF a, PointF b, PointF c)
        {
            float res = (b.Y - a.Y) * (c.X - b.X) -
                      (c.Y - b.Y) * (b.X - a.X);

            if (res == 0)
                return 0;
            if (res > 0)
                return 1;
            return -1;
        }

        public class PointFComparer : IComparer<PointF>
        {
            public int Compare(PointF p1, PointF q1)
            {
                PointF p = new PointF(p1.X - mid.X,
                                             p1.Y - mid.Y);
                PointF q = new PointF(q1.X - mid.X,
                                             q1.Y - mid.Y);

                int one = Quad(p);
                int two = Quad(q);

                if (one != two)
                    return (one < two ? -1 : 1);
                return (p.Y * q.X < q.Y * p.X ? -1 : 1);
            }
        }
    }


}