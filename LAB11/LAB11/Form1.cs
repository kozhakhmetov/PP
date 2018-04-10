using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB11
{
    public partial class Form1 : Form
    {
        Graphics g;

        Bitmap spaceship = new Bitmap(@"spaceship.png");
        Bitmap asteroid = new Bitmap(@"asteroid.png");
        
        int[] dx = new int[7];
        int[] dy = new int[7];

        PictureBox[] asteroids = new PictureBox[10];

        Random rnd = new Random();

        bool first = false;

        bool Gameover = false;

        List<Point>Bullets = new List<Point>();

        
        public Form1()
        {
            
            InitializeComponent();
            g = CreateGraphics();

            for (int i = 0; i < 7; ++i) {
                dx[i] = rnd.Next(1, 5);
                dy[i] = rnd.Next(1, 5);
            }
           

            for (int i = 0; i < 7; ++i) {

                PictureBox current = new PictureBox
                {
                    Name = "asteroid" + Convert.ToString(i),
                    Size = new Size(rnd.Next(50, 150),rnd.Next(50, 150)),
                    Location = new Point(rnd.Next(1, 1800), rnd.Next(1, 1400)),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Image = asteroid,              
                };

                asteroids[i] = current;
                Controls.Add(asteroids[i]);

                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = spaceship;

            }
            BackColor = Color.Black;

        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            for (int i = 0; i < Bullets.Count; ++i)
            {
                e.Graphics.FillEllipse(new SolidBrush(Color.Red), new Rectangle(Bullets[i], new Size(20, 20)));
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode) {
                case Keys.A:
                    pictureBox1.Location = new Point(pictureBox1.Location.X - 20, pictureBox1.Location.Y);
                    break;
                case Keys.D:
                    pictureBox1.Location = new Point(pictureBox1.Location.X + 20, pictureBox1.Location.Y);
                    break;
                case Keys.S:
                    pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y + 20);
                    break;
                case Keys.W:
                    pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y - 20);
                    break;
                case Keys.Space:
                    Bullets.Add(new Point(pictureBox1.Location.X + pictureBox1.Width / 2 - 10, pictureBox1.Location.Y));
                    break;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Gameover == true)
            {
                return;
            }
            for (int i = 0; i < Bullets.Count; ++i)
            {
                Bullets[i] = new Point(Bullets[i].X, Bullets[i].Y - 20);
            }

            while (Bullets.Count > 0 && Bullets[0].Y < 0) Bullets.RemoveAt(0);
            Refresh();

            for (int i = 0; i < 7; ++i) { 
                asteroids[i].Location = new Point(asteroids[i].Location.X + dx[i], asteroids[i].Location.Y + dy[i]);
                if (asteroids[i].Location.Y < 0 || asteroids[i].Location.Y > Height) dy[i] *= -1;
                if (asteroids[i].Location.X < 0 || asteroids[i].Location.X > Width) dx[i] *= -1;
                
                if (Controls.Contains(asteroids[i]) && dointersect(asteroids[i].Location, asteroids[i].Width, asteroids[i].Height, pictureBox1.Location, pictureBox1.Width, pictureBox1.Height))
                {
                    Gameover = true;
                    MessageBox.Show("Game Over");
                    break;
                }

                for (int j = 0; j < Bullets.Count; ++j) {
                    if (dointersect(asteroids[i].Location, asteroids[i].Width, asteroids[i].Height, Bullets[j], 20, 20)) {
                        Controls.Remove(asteroids[i]);
                    }
                }
            }


        }


        public bool dointersect(Point P1, int x1, int y1, Point P2, int X1, int Y1)
        {
            int x = P1.X;
            int y = P1.Y;
            x1 += P1.X;
            y1 += P1.Y;
            int X = P2.X;
            int Y = P2.Y;
            X1 += P2.X;
            Y1 += P2.Y;
            
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
    }
}
