using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Curs_Seminar_11
{
    public partial class Form1 : Form
    {
        static Graphics gfx;
        static SolidBrush brush = new SolidBrush(Color.Black);
        static Pen pen = new Pen(Color.Black);
        static Point down;
        static List<Line> Lines = new List<Line>();
        static int radius = 3;
        static List<PointF> Points = new List<PointF>();

        class Line
        {
            public PointF p1, p2;

            public Line(PointF p1, PointF p2)
            {
                this.p1 = p1;
                this.p2 = p2;
            }

            public void Draw()
            {
                gfx.DrawLine(pen, p1, p2);
            }
        }
        public double Cross(PointF p, PointF q) => p.X * q.Y - p.Y * q.X;
        static int Orientation(PointF a, PointF b, PointF c)
        {
            float res = (b.Y - a.Y) * (c.X - b.X) -
                      (c.Y - b.Y) * (b.X - a.X);

            if (res >= 0)
                return 1;
            return -1;
        }
        static bool directionOfPointToRight(PointF A, PointF B, PointF P)
        {
            // subtracting co-ordinates of point A
            // from B and P, to make A as origin
            B.X -= A.X;
            B.Y -= A.Y;
            P.X -= A.X;
            P.Y -= A.Y;

            // Determining cross Product
            float cross_product = B.X * P.Y - B.Y * P.X;

            return cross_product >= 0;
        }
        private void FindIntersection(
    PointF p1, PointF p2, PointF p3, PointF p4, out bool segments_intersect,
    out PointF intersection
    )
        {
            PointF close_p1;
            PointF close_p2;
            bool lines_intersect = false;
            // Get the segments' parameters.
            float dx12 = p2.X - p1.X;
            float dy12 = p2.Y - p1.Y;
            float dx34 = p4.X - p3.X;
            float dy34 = p4.Y - p3.Y;

            // Solve for t1 and t2
            float denominator = (dy12 * dx34 - dx12 * dy34);

            float t1 =
                ((p1.X - p3.X) * dy34 + (p3.Y - p1.Y) * dx34)
                    / denominator;
            if (float.IsInfinity(t1))
            {
                // The lines are parallel (or close enough to it).
                lines_intersect = false;
                segments_intersect = false;
                intersection = new PointF(float.NaN, float.NaN);
                close_p1 = new PointF(float.NaN, float.NaN);
                close_p2 = new PointF(float.NaN, float.NaN);
                return;
            }
            lines_intersect = true;

            float t2 =
                ((p3.X - p1.X) * dy12 + (p1.Y - p3.Y) * dx12)
                    / -denominator;

            // Find the point of intersection.
            intersection = new PointF(p1.X + dx12 * t1, p1.Y + dy12 * t1);

            // The segments intersect if t1 and t2 are between 0 and 1.
            segments_intersect =
                ((t1 >= 0) && (t1 <= 1) &&
                 (t2 >= 0) && (t2 <= 1));

            // Find the closest points on the segments.
            if (t1 < 0)
                t1 = 0;
            else if (t1 > 1)
                t1 = 1;

            if (t2 < 0)
                t2 = 0;
            else if (t2 > 1)
                t2 = 1;

            close_p1 = new PointF(p1.X + dx12 * t1, p1.Y + dy12 * t1);
            close_p2 = new PointF(p3.X + dx34 * t2, p3.Y + dy34 * t2);
        }

        private List<PointF> NonIntersectingPolyByPoints(List<PointF> points)
        {
            PointF leftMost = new PointF(pictureBox1.Width, 0);
            PointF rightMost = new PointF(0, 0);

            for (int i = 0; i < points.Count; i++)
            {
                if (points[i].X < leftMost.X)
                    leftMost = points[i];

                if (points[i].X > rightMost.X)
                    rightMost = points[i];
            }

            points.Remove(leftMost);
            points.Remove(rightMost);

            List<PointF> A = new List<PointF>();
            List<PointF> B = new List<PointF>();

            foreach (PointF point in points)
            {
                if (directionOfPointToRight(leftMost, rightMost, point))
                    B.Add(point);
                else
                    A.Add(point);
            }

            A = A.OrderBy(x => x.X).ToList();
            B = B.OrderByDescending(x => x.X).ToList();

            List<PointF> sortedPoints = new List<PointF>();

            sortedPoints.Add(leftMost);
            sortedPoints.AddRange(A);
            sortedPoints.Add(rightMost);
            sortedPoints.AddRange(B);

            A.Insert(0, leftMost);
            A.Add(rightMost);

            B.Insert(0, rightMost);
            B.Add(leftMost);

            A.AddRange(B);

            return A;
        }
        public Form1()
        {
            InitializeComponent();
            gfx = pictureBox1.CreateGraphics();
            gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            gfx.FillEllipse(brush, e.X - radius, e.Y - radius, radius * 2, radius * 2);
            down = new Point(e.X, e.Y);
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            gfx.FillEllipse(brush, e.X - radius, e.Y - radius, radius * 2, radius * 2);
            Line line = new Line(down, new Point(e.X, e.Y));
            Lines.Add(line);
            line.Draw();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Lines.Count - 1; i++)
                for (int j = i + 1; j < Lines.Count; j++)
                {
                    bool intersects = false;
                    PointF intersection;
                    FindIntersection(Lines[i].p1, Lines[i].p2, Lines[j].p1, Lines[j].p2, out intersects, out intersection);
                    if (intersects)
                        Points.Add(intersection);
                }

            foreach (var point in Points)
                gfx.FillEllipse(new SolidBrush(Color.Red), point.X - radius, point.Y - radius, radius * 2, radius * 2);

            gfx.FillPolygon(new SolidBrush(Color.Blue), NonIntersectingPolyByPoints(Points).ToArray());
        }
    }
}
