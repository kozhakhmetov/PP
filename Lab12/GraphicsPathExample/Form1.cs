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

namespace GraphicsPathExample
{
    public partial class Form1 : Form
    {
        Graphics g;
        GraphicsPath path;
        public Form1()
        {
            InitializeComponent();
            g = CreateGraphics();
            path = new GraphicsPath();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            path.AddLine(new Point(10, 10), new Point(10, 100));
            path.AddRectangle(new Rectangle(20, 100, 100, 100));

            g.DrawPath(Pens.Red, path);

            //path.Reset();
        }
    }
}
