using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuickHull
{
    public partial class QuickHullForm : Form
    {
        public QuickHullForm()
        {
            InitializeComponent();
        }

        static Random rng = new Random();
        static int pointRadius = 4;
        static Graphics gfx;


        private void RandomBtn_Click(object sender, EventArgs e)
        {
            List<PointF> points = RandomPoints(int.Parse(textBox1.Text));
            QuickHullAlgorithm(points);
        }

        public List<PointF> RandomPoints(int count = 50) =>
            Enumerable.Range(0, count)
            .Select(x => new PointF(rng.Next(pointRadius, Canvas.Width - pointRadius), rng.Next(pointRadius, Canvas.Height - pointRadius)))
            .ToList();

        public void QuickHullAlgorithm(List<PointF> points)
        {
            QuickHullGraphics.Clear();
            QuickHullGraphics.DrawPoints(points);

            List<PointF> resultHull = QuickHull.ConvexHull(points);

            QuickHullGraphics.FinishLines(resultHull);
        }

        private void QuickHullForm_Load(object sender, EventArgs e)
        {
            gfx = Canvas.CreateGraphics();
            gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            QuickHullGraphics.Initialize(gfx);
        }

        private void GenerateBtn_Click(object sender, EventArgs e)
        {
            string[] lines = textBox2.Text.Split(Environment.NewLine);
            List<PointF> points = new List<PointF>();

            for (int i = 0; i < lines.Length; i++)
            {
                Point point = new Point(int.Parse(lines[i].Split(' ')[0]), int.Parse(lines[i].Split(' ')[1]));
                points.Add(point);
            }

            QuickHullAlgorithm(points);
        }
    }
}
