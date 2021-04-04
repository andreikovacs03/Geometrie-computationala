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

        public List<PointF> RandomPoints(int separatePlus, int separateMinus, int count = 5) =>
          Enumerable.Range(0, count)
          .Select(x => new PointF(rng.Next(pointRadius + separatePlus, Canvas.Width - separateMinus - pointRadius), rng.Next(pointRadius, Canvas.Height - pointRadius)))
          .ToList();

        private void MergeBtn_Click(object sender, EventArgs e)
        {
            ConvexHullSolver solver = new ConvexHullSolver(Gfx, Canvas);
            List<PointF> pointsA = RandomPoints(0,Canvas.Width / 2);
            List<PointF> pointsB = RandomPoints(Canvas.Width / 2, 0);

            pointsA = QuickHull.ConvexHull(pointsA);
            pointsB = QuickHull.ConvexHull(pointsB);
        }

        private void DivideAndConquerForm_Load(object sender, EventArgs e)
        {
            Gfx = Canvas.CreateGraphics();
            QuickHullGraphics.Initialize(Gfx);
        }
    }
}
