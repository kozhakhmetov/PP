using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB11
{
    public partial class Form1 : Form
    {
        Graphics g;
        Point[] points = {new Point(0, 0),  new Point(20, 20), new Point(80, 40), new Point(35, 50), new Point(25, 80), new Point(-20, 70), new Point(-20, 20) };
        Point[] spaceship = { new Point(10, 0), new Point(25, 25), new Point(10, 50), new Point(-10, 50), new Point(-25, 25), new Point(-10, 0) };
        public Form1()
        {
            InitializeComponent();
            g = CreateGraphics();
            Height = 1000;
            Width = 1000;
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            BackColor = Color.Blue;
            e.Graphics.FillEllipse(new SolidBrush(Color.White), 50, 50, 20, 20);
            e.Graphics.FillEllipse(new SolidBrush(Color.White), 100, 120, 20, 20);
            e.Graphics.FillEllipse(new SolidBrush(Color.White), 301, 120, 20, 20);
            e.Graphics.FillEllipse(new SolidBrush(Color.White), 300, 200, 20, 20);
            e.Graphics.FillEllipse(new SolidBrush(Color.White), 500, 420, 20, 20);      
            e.Graphics.FillEllipse(new SolidBrush(Color.White), 10, 10, 20, 20);
            e.Graphics.FillEllipse(new SolidBrush(Color.White), 500, 500, 20, 20);

            DrawAsteroid(150, 150, new SolidBrush(Color.Red));

            DrawSpaceShip(10, 10, new SolidBrush(Color.Yellow));
        }
        public void DrawAsteroid(int x, int y, SolidBrush c) {
            Point[] newpoints = points;
            for (int i = 0; i < points.Length; i++) {
                newpoints[i].X += x;
                newpoints[i].Y += y;
            }
            g.FillPolygon(c, newpoints);
        }
        public void DrawSpaceShip(int x, int y, SolidBrush c) {
            Point[] newpoints = spaceship;
            for (int i = 0; i < spaceship.Length; i++) {
                newpoints[i].X += x;
                newpoints[i].Y += y;
            }
            g.FillPolygon(c, newpoints);
        }
    }
}
