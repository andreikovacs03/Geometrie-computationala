using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Curs_Seminar_3
{
    public partial class Form1 : Form
    {
        private static Graphics gfx;

        public Form1()
        {
            InitializeComponent();
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PointF[] points = new PointF[3];
            string[] input = textBox1.Text.Split(new[] { ' ' });
            points[0] = new PointF(int.Parse(input[0]), int.Parse(input[1]));

            input = textBox2.Text.Split(new[] { ' ' });
            points[1] = new PointF(int.Parse(input[0]), int.Parse(input[1]));

            input = textBox3.Text.Split(new[] { ' ' });
            points[2] = new PointF(int.Parse(input[0]), int.Parse(input[1]));

            PointF[] medians = new PointF[3];
            Pen pen = new Pen(Color.Black);


            gfx.Clear(Color.White);
            gfx.DrawPolygon(pen, points);

            gfx.DrawLine(new Pen(Color.Red), points[2], new PointF((points[0].X + points[1].X) / 2, (points[0].Y + points[1].Y) / 2));
            gfx.DrawLine(new Pen(Color.Red), points[0], new PointF((points[1].X + points[2].X) / 2, (points[1].Y + points[2].Y) / 2));
            gfx.DrawLine(new Pen(Color.Red), points[1], new PointF((points[0].X + points[2].X) / 2, (points[0].Y + points[2].Y) / 2));

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gfx = pictureBox1.CreateGraphics();
        }
    }
}
