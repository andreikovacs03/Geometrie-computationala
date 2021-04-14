using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;

namespace QuickHull
{
    public static class QuickHullGraphics
    {
        public static Graphics Gfx { get; set; }
        public static void Initialize(Graphics gfx, int pointRadius = 4)
        {
            Gfx = gfx;
            PointRadius = pointRadius;
        }

        static SolidBrush PointBrush = new SolidBrush(Color.Red);
        static Pen PointPen = new Pen(Color.Black);
        static int PointRadius;
        static Pen LinePen = new Pen(Color.Blue, 3);
        static Color BaseColor = Color.White;

        public static void DrawPoints(List<PointF> points)
        {
            foreach (var point in points)
            {
                Gfx.FillEllipse(PointBrush, point.X - PointRadius, point.Y - PointRadius, PointRadius * 2, PointRadius * 2);
                Gfx.DrawEllipse(PointPen, point.X - PointRadius, point.Y - PointRadius, PointRadius * 2, PointRadius * 2);
            }
        }

        public static void Clear() => Gfx.Clear(BaseColor);

        public static void DrawLines(List<PointF> points)
        {
            Thread.Sleep(1000);
            Gfx.DrawLines(LinePen, points.ToArray());
        }

        public static void FinishLines(List<PointF> points)
        {
            Thread.Sleep(1000);
            Gfx.DrawPolygon(new Pen(Color.Green, 4), points.ToArray());
        }
    }
}
