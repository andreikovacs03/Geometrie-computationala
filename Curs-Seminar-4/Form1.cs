using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Curs_Seminar_4
{
    public partial class Form1 : Form
    {
        private static Graphics gfx;
        private Random rng = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gfx = pictureBox1.CreateGraphics();
            gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Problem1();
        }

        private void Problem1()
        {
            Pen pen = new Pen(Color.Black);
            string[] text = textBox1.Text.Split(' ');
            Point point = new Point(int.Parse(text[0]), int.Parse(text[1]));

            text = textBox2.Text.Split(' ');
            Size size = new Size(int.Parse(text[0]), int.Parse(text[1]));

            Rectangle rect = new Rectangle(point, size);

            gfx.DrawRectangle(pen, rect);
            DrawMidLines(rect);
            DrawAxis(rect);
        }

        private Rectangle GenerateRectangle()
        {
            int rectSize = rng.Next(200);
            Size size = new Size(rectSize, rectSize);
            Point point = new Point(rng.Next(pictureBox1.Size.Width - size.Width),
                rng.Next(pictureBox1.Size.Height - size.Height));

            return new Rectangle(point, size);
        }

        private Color RandomColor() => Color.FromArgb(rng.Next(256), rng.Next(256), rng.Next(256));

        private void DrawRandomRectangles()
        {
            Pen pen = new Pen(RandomColor());
            for (int i = 0; i < 20; i++)
                gfx.DrawRectangle(pen, GenerateRectangle());
        }

        private void DrawRandomCircles()
        {
            Pen pen = new Pen(Color.FromArgb(rng.Next(256), rng.Next(256), rng.Next(256)));
            for (int i = 0; i < 20; i++)
                gfx.DrawEllipse(pen, GenerateRectangle());
        }

        private void DrawMidLines(Rectangle rect)
        {
            gfx.DrawLine(new Pen(Color.Red), rect.X + rect.Width / 2, rect.Y, rect.X + rect.Width / 2, rect.Y + rect.Height);
            gfx.DrawLine(new Pen(Color.Red), rect.X, rect.Y + rect.Height / 2, rect.X + rect.Width, rect.Y + rect.Height / 2);
        }

        private void DrawAxis(Rectangle rect)
        {
            gfx.DrawLine(new Pen(Color.Green), rect.X, rect.Y, rect.X + rect.Width, rect.Y + rect.Height);
            gfx.DrawLine(new Pen(Color.Green), rect.X + rect.Width, rect.Y, rect.X, rect.Y + rect.Height);
        }

        private void DrawPoly()
        {
            int sides = int.Parse(textBox3.Text);
            PointF[] points = new PointF[sides];

            string[] text = textBox7.Text.Split(' ');

            PointF center = new PointF(float.Parse(text[0]), float.Parse(text[1]));
            float radius = float.Parse(textBox4.Text);
            double theta = Math.PI / sides;

            for (int i = 0; i < points.Length; i++)
            {
                points[i] = new PointF(center.X + radius * (float)Math.Cos(theta), center.Y + radius * (float)Math.Sin(theta));
                theta += 2 * Math.PI / sides;
            }


            gfx.FillPolygon(new SolidBrush(RandomColor()), points);
            gfx.DrawPolygon(new Pen(Color.Black), points);
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
        private void DrawNonIntersectingPoly()
        {
            gfx.Clear(Color.White);
            int sides = int.Parse(textBox8.Text);

            List<PointF> points = new List<PointF>();

            PointF leftMost = new PointF(pictureBox1.Width, 0);
            PointF rightMost = new PointF(0, 0);

            for (int i = 0; i < sides; i++)
            {
                PointF point = new PointF(rng.Next(pictureBox1.Width), rng.Next(pictureBox1.Height));
                if (point.X < leftMost.X)
                    leftMost = point;

                if (point.X > rightMost.X)
                    rightMost = point;

                points.Add(point);
            }

            gfx.FillEllipse(new SolidBrush(Color.Black), leftMost.X - 5, leftMost.Y - 5, 10, 10);
            gfx.FillEllipse(new SolidBrush(Color.Black), rightMost.X - 5, rightMost.Y - 5, 10, 10);

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

            //gfx.FillPolygon(new SolidBrush(Color.RoyalBlue), sortedPoints.ToArray());
            A.Insert(0, leftMost);
            A.Add(rightMost);

            B.Insert(0, rightMost);
            B.Add(leftMost);

            gfx.DrawLines(new Pen(Color.Red, 10), A.ToArray());
            gfx.DrawLines(new Pen(Color.Green, 10), B.ToArray());
            A.AddRange(B);
            textBox9.Text = Area(A).ToString();
        }

        private void DrawNonIntersectingPolyByPoints()
        {
            gfx.Clear(Color.White);
            string[] lines = textBox10.Text.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            List<PointF> points = new List<PointF>();

            foreach (var line in lines)
                points.Add(new PointF(int.Parse(line.Split(' ')[0]) * 10, int.Parse(line.Split(' ')[1]) * 10));

            PointF leftMost = new PointF(pictureBox1.Width, 0);
            PointF rightMost = new PointF(0, 0);

            for (int i = 0; i < points.Count; i++)
            {
                if (points[i].X < leftMost.X)
                    leftMost = points[i];

                if (points[i].X > rightMost.X)
                    rightMost = points[i];
            }

            gfx.FillEllipse(new SolidBrush(Color.Black), leftMost.X - 5, leftMost.Y - 5, 10, 10);
            gfx.FillEllipse(new SolidBrush(Color.Black), rightMost.X - 5, rightMost.Y - 5, 10, 10);

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

            //gfx.FillPolygon(new SolidBrush(Color.RoyalBlue), sortedPoints.ToArray());
            A.Insert(0, leftMost);
            A.Add(rightMost);

            B.Insert(0, rightMost);
            B.Add(leftMost);

            gfx.DrawLines(new Pen(Color.Red), A.ToArray());
            gfx.DrawLines(new Pen(Color.Green), B.ToArray());
            A.AddRange(B);
            textBox9.Text = Area(A).ToString();
        }

        float sign(PointF p1, PointF p2, PointF p3)
        {
            return (p1.X - p3.X) * (p2.Y - p3.Y) - (p2.X - p3.X) * (p1.Y - p3.Y);
        }

        bool PointInTriangle(PointF pt, PointF v1, PointF v2, PointF v3)
        {
            float d1, d2, d3;
            bool has_neg, has_pos;

            d1 = sign(pt, v1, v2);
            d2 = sign(pt, v2, v3);
            d3 = sign(pt, v3, v1);

            has_neg = (d1 < 0) || (d2 < 0) || (d3 < 0);
            has_pos = (d1 > 0) || (d2 > 0) || (d3 > 0);

            return !(has_neg && has_pos);
        }

        void ConvexHull()
        {
            int pointCount = int.Parse(textBox8.Text);

        }
        // A.X A.Y 1
        // B.X B.Y 1
        // O.X O.Y 1
        float CrossProduct(PointF a, PointF b) => a.X * b.Y - a.Y * b.X;
        float Area(List<PointF> points)
        {
            double sum = 0f;
            for (int i = 0; i < points.Count; i++)
                sum += CrossProduct(points[i], points[(i + 1) % points.Count]);

            return (float)Math.Abs(sum) / 2f;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DrawRandomRectangles();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DrawRandomCircles();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DrawPoly();
        }

        private void button7_Click(object sender, EventArgs e)
        {
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            DrawNonIntersectingPoly();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DrawNonIntersectingPolyByPoints();
        }
    }
}
