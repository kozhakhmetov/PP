using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintExample3
{
    public partial class Form1 : Form
    {
        Graphics g;
        GraphicsPath path;
        Pen pen;
        Point prev;
        Bitmap btm;
        string tool = "Pen";
        int[] dx = {0, 1, 0, -1};
        int[] dy = {1, 0, -1, 0};
        int[,] used = new int[2000, 2000];
        int cnt = 1;

        Queue<Point> q = new Queue<Point>();

        public Form1()
        {
            InitializeComponent();

            pen = new Pen(Color.Red, 3);
            path = new GraphicsPath();
            
            // Main graphics
            btm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = btm;
            
            // Create graphics from Bitmap
            g = Graphics.FromImage(btm);
            g.Clear(Color.White);
        }

        private void Check(Point p, Color initial) {
            if (p.X >= btm.Width || p.X < 0 || p.Y < 0 || p.Y >= btm.Height) {
                return;
            }
            if (used[p.X, p.Y] == cnt) return; 
            if (btm.GetPixel(p.X, p.Y) == initial) {
                btm.SetPixel(p.X, p.Y, pen.Color);
                used[p.X, p.Y] = cnt;
                q.Enqueue(p);
            }
        }

        void Fill(Point start) {
            Color initial = btm.GetPixel(start.X, start.Y);

            if (initial.G == pen.Color.G && initial.R == pen.Color.R && pen.Color.B == initial.B) return;

            q.Clear();

            q.Enqueue(start);

            used[start.X, start.Y] = cnt;

            while (q.Count > 0) {
                Point current = q.Dequeue();
                for (int i = 0; i < 4; ++i) {
                    Check(new Point(current.X + dx[i], current.Y + dy[i]), initial);
                }
            }
            cnt++;
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            // save clicked position of mouse
            prev = e.Location;
            if (tool == "Fill") {
                Fill(e.Location);
                Refresh();
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            // remove all previous shapes in GraphicsPath
            path.Reset();

            // check for mouse left button clicked
            if (e.Button == MouseButtons.Left)
            {
                // get current location of mouse
                Point cur = e.Location;

                Point pnt = new Point(prev.X, cur.Y);
                Point pnt1 = new Point(cur.X, prev.Y);
                List<Point> points = new List<Point>();

                points.Add(cur); points.Add(prev);
                points.Add(pnt); points.Add(pnt1);
                points.Sort(Compare);

                if (tool == "Rectangle")
                {
                    // add shape to path
                    path.AddRectangle(new Rectangle(points[1], new Size(points[2].X - points[1].X, points[2].Y - points[1].Y)));
                }

                if (tool == "Line")
                {
                    path.AddLine(prev, cur);
                }

                if (tool == "Pen")
                {
                    g.DrawLine(pen, prev, cur);
                    prev = cur;
                }

                if (tool == "Ellipse")
                {
                    path.AddEllipse(new Rectangle(prev.X, prev.Y, cur.X - prev.X, cur.Y - prev.Y));
                }

                if (tool == "Circle")
                {
                    int mn = Math.Min(Math.Abs(points[1].X - points[2].X), Math.Abs(points[1].Y - points[2].Y));
                    path.AddEllipse(new Rectangle(points[1], new Size(mn, mn)));
                }

                if (tool == "Triangle")
                {
                    path.AddLine(points[0], points[1]);
                    path.AddLine(points[0], points[2]);
                    path.AddLine(points[1], points[2]);
                }

                if (tool == "Triangle2")
                {
                    Point newpoint = new Point((points[1].X + points[3].X) / 2, points[1].Y);

                    path.AddLine(points[0], points[2]);
                    path.AddLine(points[0], newpoint);
                    path.AddLine(points[2], newpoint);
                }

                if (tool == "Rombus")
                {
                    PointF[] corners = {
                        new PointF((float)(points[1].X + points[3].X) / 2, points[1].Y),
                        new PointF(points[2].X, (float)(points[2].Y + points[3].Y) / 2),
                        new PointF((points[0].X + points[2].X) / 2, points[0].Y),
                        new PointF(points[1].X, (points[1].Y + points[0].Y) / 2),
                    };

                    path.AddPolygon(corners);
                }

                if (tool == "Star")
                {
                    PointF[] corners = {
                        new PointF(Math.Abs(points[1].X + points[3].X) / 2, points[1].Y),
                        new PointF(points[2].X - (float)Math.Abs(points[2].X - points[0].X) / 6, points[0].Y),
                        new PointF(points[1].X, points[1].Y + (float)Math.Abs(points[1].Y - points[0].Y) / 3),
                        new PointF(points[3].X, points[3].Y + (float)Math.Abs(points[3].Y - points[2].Y) / 3),
                        new PointF(points[0].X + (float)Math.Abs(points[2].X - points[0].X) / 6, points[0].Y),
                    };
                    path.AddPolygon(corners);
                }

                if (tool == "Hexagone") {
                    PointF[] corners = {
                        new PointF(points[1].X + (float)Math.Abs(points[1].X - points[3].X) / 2, points[1].Y),
                        new PointF(points[3].X, points[3].Y + (float)Math.Abs(points[3].Y - points[2].Y) / 3),
                        new PointF(points[3].X, points[2].Y - (float)Math.Abs(points[3].Y - points[2].Y) / 3),
                        new PointF(points[0].X + (float)Math.Abs(points[0].X - points[2].X) / 2, points[0].Y),
                        new PointF(points[0].X, points[0].Y - (float)Math.Abs(points[1].Y - points[0].Y) / 3),
                        new PointF(points[0].X, points[1].Y + (float)Math.Abs(points[1].Y - points[0].Y) / 3),
                    };
                    path.AddPolygon(corners);
                }

                // redraw picturebox
                pictureBox1.Refresh();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            // if GraphicsPath not empty draw last position of the shape in Main Graphics(Bitmap)
            if (path != null)
                g.DrawPath(pen, path);

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // Draw all temporary shapes in Graphics of picturebox
            e.Graphics.DrawPath(pen, path);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

            pen.Width = (float)numericUpDown1.Value;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            pen.Color = colorDialog1.Color;
        }

        private static int Compare(Point x, Point y) {
            if (x.X == y.X)
            {
                if (x.Y > y.Y) return -1;
                if (x.Y == y.Y) return 0;
                return 1;
            }
            if (x.X < y.X) return -1;
            if (x.X > y.X) return 1;
            return 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)(sender);
            tool = btn.Text;
        }

        private void toolStripTextBox3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "jpeg files (*.jpeg)|*.jpeg|png files (*.png)|*.png|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.CheckFileExists == true)
                btm.Save(saveFileDialog1.FileName);
        }

        private void toolStripTextBox4_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            pictureBox1.Image = btm;
        }

        private void toolStripTextBox5_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();

            btm = (Bitmap)Image.FromFile(openFileDialog.FileName);

            g = Graphics.FromImage(btm);
            pictureBox1.Image = btm;
        }
    }
}
