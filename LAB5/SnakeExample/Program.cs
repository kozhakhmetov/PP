using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeExample
{
    class Program
    {
        static public Snake snake = new Snake();
        static public Wall wall = new Wall();
        static public Food food = new Food();
        static public int score = 0;
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(70, 20);
            while (true)
            {
                snake.Draw();
                food.Draw();
                wall.Draw();

                Console.SetCursorPosition(0, 21);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(score);

                ConsoleKeyInfo btn = Console.ReadKey();
                switch (btn.Key)
                {
                    case ConsoleKey.UpArrow:
                        snake.Move(0, -1);
                        break;
                    case ConsoleKey.DownArrow:
                        snake.Move(0, 1);
                        break;
                    case ConsoleKey.LeftArrow:
                        snake.Move(-1, 0);
                        break;
                    case ConsoleKey.RightArrow:
                        snake.Move(1, 0);
                        break;
                }
            }


        }
        static public void write(int x, int y, char sign, ConsoleColor c = ConsoleColor.Black)
        {
            Console.ForegroundColor = c;
            Console.SetCursorPosition(x, y);
            Console.Write(sign);
        }
        static public bool contains(List<Point> a, Point b)
        {
            foreach (Point p in a) if (p.x == b.x && p.y == b.y) return true;
            return false;
        }
    }
}
