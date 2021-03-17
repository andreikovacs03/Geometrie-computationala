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
    }
}
