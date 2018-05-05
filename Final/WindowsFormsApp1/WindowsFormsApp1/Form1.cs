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
        Button[,] btn = new Button[4, 4];
        int cnt = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Cur_Click(object sender, EventArgs e)
        {
            Button Btn = (Button)(sender);
            if (Btn.Text != "") return;
            if (cnt % 2 == 0)
            {
                Btn.Text = "X";
            }
            else {
                Btn.Text = "O";
            }
            for (int i = 0; i < 3; ++i) {
                if (btn[i, 0].Text == btn[i, 1].Text && btn[i, 1].Text == btn[i, 2].Text && btn[i, 0].Text != "") {
                    if (btn[i, 0].Text == "X") {
                        MessageBox.Show("X wins");
                    }
                    if (btn[i, 0].Text == "O") {
                        MessageBox.Show("O wins");
                    }
                }
                if (btn[0, i].Text == btn[1, i].Text && btn[2, i].Text == btn[1, i].Text && btn[1, i].Text != "") {
                    if (btn[0, i].Text == "X")
                    {
                        MessageBox.Show("X wins");
                    }
                    if (btn[0, i].Text == "O")
                    {
                        MessageBox.Show("O wins");
                    }
                }
            }
            if (btn[0, 0].Text == btn[1, 1].Text && btn[1, 1].Text == btn[2, 2].Text && btn[0, 0].Text != "") {
                if (btn[0, 0].Text == "X")
                {
                    MessageBox.Show("X wins");
                }
                if (btn[0, 0].Text == "O")
                {
                    MessageBox.Show("O wins");
                }
            }
            if (btn[0, 2].Text == btn[1, 1].Text && btn[1, 1].Text == btn[2, 0].Text && btn[2, 0].Text != "") {
                if (btn[0, 2].Text == "X")
                {
                    MessageBox.Show("X wins");
                }
                if (btn[0, 2].Text == "O")
                {
                    MessageBox.Show("O wins");
                }
            }
            cnt++;
            if (cnt == 9) {
                MessageBox.Show("Draw");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Controls.Remove(button1);
            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    Button cur = new Button
                    {
                        Location = new Point(i * 100, j * 100),
                        Height = 90,
                        Width = 90,
                    };
                    cur.Click += Cur_Click;
                    btn[i, j] = cur;
                    Controls.Add(btn[i, j]);
                }
            }
        }
    }
}
