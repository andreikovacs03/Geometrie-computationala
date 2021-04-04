using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace QuickHull
{
    public static class QuickHull
    {
        static List<PointF> resultHull = new List<PointF>();

        static float upperDistance(PointF A, PointF B, PointF C) =>
            (C.Y - A.Y) * (B.X - A.X) -
            (B.Y - A.Y) * (C.X - A.X);

        static void FindFarthestPoint(List<PointF> points, PointF A, PointF B)
        {
            float distance = 0;
            PointF upperPoint = new PointF();
            foreach (var point in points)
            {
                float lineDist = upperDistance(A, B, point);
                if (lineDist > distance)
                {
                    distance = lineDist;
                    upperPoint = point;
                }
            }

            if (distance == 0)
            {
                resultHull.Add(A);
                resultHull.Add(B);
                QuickHullGraphics.DrawLines(resultHull);
                return;
            }

            FindFarthestPoint(points, A, upperPoint);
            FindFarthestPoint(points, upperPoint, B);
        }

        public static List<PointF> ConvexHull(List<PointF> points)
        {
            if (points.Count < 3)
                throw new ArgumentException("There must be at least 3 points!");

            resultHull.Clear();

            PointF leftPoint = points[0];
            PointF rightPoint = points[0];

            foreach (var point in points)
            {
                if (point.X < leftPoint.X)
                    leftPoint = point;
                if (point.X > rightPoint.X)
                    rightPoint = point;
            }

            points.Remove(leftPoint);
            points.Remove(rightPoint);

            FindFarthestPoint(points, leftPoint, rightPoint);
            FindFarthestPoint(points, rightPoint, leftPoint);

            return resultHull;
        }
    }
}
