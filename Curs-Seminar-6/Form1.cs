using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Curs_Seminar_6
{
    public partial class Form1 : Form
    {

        static Graphics gfx;
        static List<Point> points;
        static Random rng;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gfx = pictureBox1.CreateGraphics();
            points = new List<Point>();
            rng = new Random();
        }

        private void button1_Click(object sender, EventArgs e) => GeneratePoints();

        public void GeneratePoints()
        {
            int count = int.Parse(textBox1.Text);
            points.RemoveRange(0, points.Count);
            for (int i = 0; i < count; i++)
            {
                Point point = new Point(rng.Next(pictureBox1.Location.X, pictureBox1.Width), rng.Next(pictureBox1.Location.Y, pictureBox1.Height));
                points.Add(point);
            }

            DrawPoints();
        }

        public void DrawPoints()
        {
            gfx.Clear(Color.White);
            foreach (var point in points)
            {
                gfx.FillEllipse(new SolidBrush(Color.Red), point.X - 3, point.Y - 3, 6, 6);
                gfx.DrawEllipse(new Pen(Color.Black), point.X - 3, point.Y - 3, 6, 6);
            }
        }

        public void DrawLines() => gfx.DrawPolygon(new Pen(Color.Green), points.ToArray());

        private void button2_Click(object sender, EventArgs e)
        {
            points = Jarvis.convexHull(points);
            DrawLines();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            points.RemoveRange(0, points.Count);
            string[] lines = textBox2.Text.Split(Environment.NewLine);

            for (int i = 0; i < lines.Length; i++)
            {
                Point point = new Point(int.Parse(lines[i].Split(' ')[0]), int.Parse(lines[i].Split(' ')[1]));
                points.Add(point);
            }
            DrawPoints();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            points = Graham.ConvexHull(points);
            DrawLines();
        }
    }
}
