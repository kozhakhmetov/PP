using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeExample
{
    class Wall
    {
        public List<Point> body;
        public char sign;
        public ConsoleColor color;

        public Wall()
        {
            color = ConsoleColor.Red;
            sign = '#';
            body = new List<Point>();

            LoadLevel(1);
        }

        public void LoadLevel(int level)
        {
            body.Clear();


            string filePath = string.Format(@"C:\Users\Adilkhan\Desktop\PP\LAB5\SnakeExample\Levels\level{0}.txt", level);
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            string line = "";
            int i = 0;
            int row = 0;
            while(i < 20)
            {
                line = sr.ReadLine();
                for (int col = 0; col < line.Length; col++)
                {
                    if (line[col] == '#')
                    {
                        body.Add(new Point(col, row));
                    }
                }
                i++;
                row++;
            }
        }

        public void Draw()
        {
            Console.ForegroundColor = color;
            foreach (Point p in body)
            {
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(sign);
            }
        }
    }
}
