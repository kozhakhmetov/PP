using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        List<Label> labels = new List<Label>();

        bool Gameover = false;
        public Form1()
        {
            InitializeComponent();
            labels.Add(label1);
            labels.Add(label2);
            labels.Add(label3);
            labels.Add(label4);
            labels.Add(label5);
            labels.Add(label6);
            labels.Add(label7);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Gameover == true) return;
            for (int i = 0; i < labels.Count; ++i) {
                labels[i].Location = new Point(labels[i].Location.X, (labels[i].Location.Y + 20) % Height);
            }
            for (int i = 0; i < labels.Count; ++i) {
                if (dointersect(label8.Location.X, label8.Location.Y,
                    label8.Location.X + label8.Width, label8.Location.Y + label8.Height,
                    labels[i].Location.X, labels[i].Location.Y,
                    labels[i].Location.X + labels[i].Width, 
                    labels[i].Location.Y + labels[i].Height)) {
                    Gameover = true;

                    MessageBox.Show("Game over");
                    return;
                }
            }
            label1 = labels[0];
            label2 = labels[1];
            label3 = labels[2];
            label4 = labels[3];
            label5 = labels[4];
            label6 = labels[5];
            label7 = labels[6];
        
        }

        public bool dointersect(int x, int y, int x1, int y1, int X, int Y, int X1, int Y1) {
            if (x <= X && X <= x1 && y <= Y && Y <= y1)
            {
                return true;
            }
            if (x <= X1 && X1 <= x1 && y <= Y && Y <= y1)
            {
                return true;
            }
            if (x <= X && X <= x1 && y <= Y1 && Y <= y1)
            {
                return true;
            }
            if (x <= X1 && X1 <= x1 && y <= Y1 && Y1 <= y1)
            {
                return true;
            }
            return false;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == 'a') {
                label8.Location = new Point(label8.Location.X - 20, label8.Location.Y);
            }
            if (ch == 'd') {
                label8.Location = new Point(label8.Location.X + 20, label8.Location.Y);
            }
        }
    }
}
