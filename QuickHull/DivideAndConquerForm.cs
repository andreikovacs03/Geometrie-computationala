using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickHull
{
    public partial class DivideAndConquerForm : Form
    {

        static Graphics Gfx;
        static Random rng = new Random();
        static int pointRadius = 4;

        public DivideAndConquerForm()
        {
            InitializeComponent();
        }

        public List<PointF> RandomPoints(int count = 10) =>
          Enumerable.Range(0, count)
          .Select(x => new PointF(rng.Next(pointRadius, Canvas.Width - pointRadius), rng.Next(pointRadius, Canvas.Height - pointRadius)))
          .ToList();

        private void MergeBtn_Click(object sender, EventArgs e)
        {
            List<PointF> points = RandomPoints(30);
            points = points.OrderBy(point => point.X).ToList();
            QuickHullGraphics.DrawPoints(points);
            points = DivideAndConquer.ConvexHull(points);
            QuickHullGraphics.Clear();
            QuickHullGraphics.FinishLines(points);
            QuickHullGraphics.DrawPoints(points);
        }

        private void DivideAndConquerForm_Load(object sender, EventArgs e)
        {
            Gfx = Canvas.CreateGraphics();
            Gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            QuickHullGraphics.Initialize(Gfx);
        }
    }
}
