using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintExample2
{
    public partial class Form1 : Form
    {
        Graphics g;
        GraphicsPath path;
        Pen pen;
        Point prev;

        public Form1()
        {
            InitializeComponent();
            g = CreateGraphics();
            path = new GraphicsPath();
            pen = new Pen(Color.Red, 2);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            prev = e.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                path.Reset();
                Point cur = e.Location;
                //path.AddLine(prev, cur);

                //path.AddRectangle(new Rectangle(prev.X, prev.Y, cur.X - prev.X, cur.Y - prev.Y));
                path.AddEllipse(new Rectangle(prev.X, prev.Y, cur.X - prev.X, cur.Y - prev.Y));

                Refresh();
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g.DrawPath(pen, path);
        }
    }
}
