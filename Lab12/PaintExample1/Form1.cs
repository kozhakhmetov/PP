using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintExample1
{
    public partial class Form1 : Form
    {
        Graphics g;
        Pen pen;
        Point prev;

        public Form1()
        {
            InitializeComponent();
            g = CreateGraphics();
            pen = new Pen(Color.Red, 1);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            prev = e.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                Point cur = e.Location;
                g.DrawLine(pen, prev, cur);
                prev = cur;
            }
        }
    }
}
