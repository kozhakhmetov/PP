using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        Graphics g;
        List<Point> circles = new List<Point>();
        List<Color> clr = new List<Color>();
        Point id = new Point(-10, -10);
        int cur = -1;
        Random rnd = new Random();
        Color[] colors = { Color.Red, Color.Blue, Color.Green, Color.Yellow };
        public Form1()
        {
            InitializeComponent();
            g = CreateGraphics();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            Controls.Remove(button1);
            for (int i = 0; i < 6; ++i) {
                clr.Add(colors[rnd.Next(0, 3)]);
                circles.Add(Generatecircle());
            }
            Refresh();
        }

        public Point Generatecircle() {
            Point pnt = new Point(rnd.Next(100, 900), rnd.Next(100, 600));
            while (!isvalid(pnt)) {
                pnt = new Point(rnd.Next(100, 900), rnd.Next(100, 600));
            }
            return pnt;
        }

        public bool isvalid(Point pnt) {
            for (int i = 0; i < circles.Count; ++i) {
                if (dist(circles[i].X, circles[i].Y, pnt.X, pnt.Y) < 10000) {
                    return false;
                }
            }
            return true;
        }
        public int dist(int x, int y, int x1, int y1) {
            return (x - x1) * (x - x1) + (y - y1) * (y - y1);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < circles.Count; ++i) {
                circles[i] = new Point(circles[i].X, circles[i].Y + 15);
            }
            if (rnd.Next(1, 6) == 1) {
                clr.Add(colors[rnd.Next(0, 3)]);
                circles.Add(Generatecircle());
            }
            List<int> toRemove = new List<int>();

            for (int i = 0; i < circles.Count; ++i) {
                if (circles[i].Y > 700)
                {
                    if (cur == i) cur = -1;
                    textBox4.Text = Convert.ToString(Convert.ToInt32(textBox4.Text) + 1);
                    toRemove.Add(i);
                }
            }

            for (int i = 0; i < toRemove.Count; ++i) {
                if (toRemove[i] - i < cur) cur--;
                circles.RemoveAt(toRemove[i] - i);
                clr.RemoveAt(toRemove[i] - i);
            }

            Refresh();
            if (Convert.ToInt32(textBox4.Text) >= 20)
            {
                
                timer1.Enabled = false;
                MessageBox.Show("Game over");
            }

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < circles.Count; ++i)
            {
                if (cur == i) {
                    g.DrawEllipse(new Pen(Color.Black, 10), new Rectangle(circles[i].X - 50, circles[i].Y - 50, 100, 100));
                }
                g.FillEllipse(new SolidBrush(clr[i]), new Rectangle(circles[i].X - 50, circles[i].Y - 50, 100, 100));
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Point loc = e.Location;
            if (cur == -1)
            {
                for (int i = 0; i < circles.Count; ++i)
                {
                    if (dist(circles[i].X, circles[i].Y, loc.X, loc.Y) < 10000)
                    {
                        cur = i;
                    }
                }
            }
            else {
                List<int> toRemove = new List<int>();
                for (int i = 0; i < circles.Count; ++i)
                {
                    if (dist(circles[i].X, circles[i].Y, loc.X, loc.Y) < 10000)
                    {
                        if (i == cur)
                        {
                            cur = -1;
                        }
                        else if (clr[cur] == clr[i])
                        {
                            toRemove.Add(cur);
                            toRemove.Add(i);
                            toRemove.Sort();
                            for (int j = 0; j < toRemove.Count; ++j)
                            {
                                circles.RemoveAt(toRemove[j] - j);
                                clr.RemoveAt(toRemove[j] - j);
                            }
                            cur = -1;
                            textBox2.Text = Convert.ToString(Convert.ToInt32(textBox2.Text) + 1);
                            if (Convert.ToInt32(textBox2.Text) % 5 == 0 && Convert.ToInt32(textBox2.Text) != 0)
                            {
                                MessageBox.Show("Level up");
                                timer1.Interval = timer1.Interval - 30;
                            }
                        }
                        else {
                            cur = -1;
                        }
                    }
                }
            }

        }
    }
}
