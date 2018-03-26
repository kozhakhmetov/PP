using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB9
{
    public partial class Form1 : Form
    {

        double value = 0;
        string operation = "";
        bool flag = false;
        double memory;
        string equalflag = "";
        double toadd = 0;
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

        }

        private void button_Click(object sender, EventArgs e)
        {
            if (Display.Text == "0" || flag == true)
            {
                Display.Clear();
            }
            Button btn = (Button)(sender);
            Display.Text += btn.Text;
            flag = false;
            equalflag = "";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Button btn = (Button)(sender);

            if (flag == false) {
                toadd = Convert.ToDouble(Display.Text);
                dooperation();
            }
            flag = true;
            equalflag = "";
            operation = btn.Text;
        }

        void dooperation()
        {
            if (operation == "+") value += toadd;
            if (operation == "-") value -= toadd;
            if (operation == "/")
            {
                if (toadd == 0)
                {
                    MessageBox.Show("Error");
                }
                else
                {
                    value /= toadd;
                }
            }
            if (operation == "x") value *= toadd;
            if (operation == "x^y") value = Math.Pow(value, toadd);
            if (operation == "Mod") value %= toadd;
            if (operation == "") value = toadd;
            if (operation != "") Display.Text = Convert.ToString(value);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (equalflag != "")
                operation = equalflag;
            else
                toadd = Convert.ToDouble(Display.Text);

            dooperation();
            flag = true;
            equalflag = operation;
            operation = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!Display.Text.Contains(','))
                Display.Text += ',';
            equalflag = "";
            flag = false;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Display.Text = "0";
            equalflag = "";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Display.Text = "0";
            value = 0;
            flag = false;
            operation = "";
            equalflag = "";
        }

        private void button18_Click(object sender, EventArgs e)
        {

            Display.Text = Display.Text.Remove(Display.Text.Length - 1);

            if (Display.Text.Length == 0)
                Display.Text = "0";
            flag = false;
            equalflag = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            equalflag = "";
            if (flag == false)
            {
                toadd = Convert.ToDouble(Display.Text);
                dooperation();
            }
            Button b = (Button)sender;
            if (b.Text == "sin") Display.Text = Convert.ToString(Math.Sin(value));
            if (b.Text == "cos") Display.Text = Convert.ToString(Math.Cos(value));
            if (b.Text == "tan") Display.Text = Convert.ToString(Math.Tan(value));

            if (b.Text == "log")
            {
                if (value < 0)
                {
                    MessageBox.Show("Error");
                }
                else
                {
                    Display.Text = Convert.ToString(Math.Log(value));
                }
            }
            if (b.Text == "!") {

                if (value < 0 || Convert.ToString(value).Contains(',') || value > 25)
                {
                    MessageBox.Show("Error");
                }
                else
                {
                    Display.Text = Convert.ToString(fact(Convert.ToInt32(value)));
                }
            }
            if (b.Text == "sqrt") {

                if (value < 0)
                {
                    MessageBox.Show("Error");
                }
                else
                {
                    Display.Text = Convert.ToString(Math.Sqrt(value));
                }
            }
            if (b.Text == "x^2") {
                Display.Text = Convert.ToString((value * value));
            }
            if (b.Text == "e^x") {
                Display.Text = Convert.ToString(Math.Pow(Math.E, value));
            }
            if (b.Text == "10^x") {
                Display.Text = Convert.ToString(Math.Pow(10, value));
            }
            if (b.Text == "1/x") {
                Display.Text = Convert.ToString(1 / value);
            }

        }

        
        public int fact(int x) {
            int res = 1;
            for (int i = 1; i <= x; ++i) res *= i;
            return res;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button33_Click(object sender, EventArgs e)
        {
            equalflag = "";
            Button b = (Button)(sender);
            if (b.Text == "MS") {
                memory = Convert.ToDouble(Display.Text);
            }
            if (b.Text == "MR") {
                Display.Text = Convert.ToString(memory);
            }
            if (b.Text == "MC") {
                memory = 0;
            }
            if (b.Text == "+M") {
                memory += Convert.ToDouble(Display.Text);
            }
            if (b.Text == "-M") {
                memory -= Convert.ToDouble(Display.Text);
            }

        }
    }
}
