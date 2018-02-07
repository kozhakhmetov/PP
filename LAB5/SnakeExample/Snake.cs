using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeExample
{
    class Snake
    {
        public List<Point> body;
        public char sign;
        public ConsoleColor color;

        public Snake() {
            sign = 'o';
            color = ConsoleColor.Yellow;
            body = new List<Point>();

            body.Add(new Point(12, 10));
            body.Add(new Point(11, 10));
            body.Add(new Point(10, 10));
        }

        public void Move(int dx, int dy) {

            Program.write(body[body.Count - 1].x, body[body.Count - 1].y, ' ');
            
            body.Insert(0, new Point(body[0].x + dx, body[0].y + dy));
            
            if (body[0].x < 0) body[0].x = 69;
            if (body[0].x > 69) body[0].x = 0;
            if (body[0].y < 0) body[0].y = 19;
            if (body[0].y > 19) body[0].y = 0;

            if (Program.food.location.x != body[0].x || Program.food.location.y != body[0].y)
            {
                body.RemoveAt(body.Count - 1);
            }
            else
            {
                Program.food.SetRandomPosition();
            }

            if (Program.contains(body.GetRange(1, body.Count - 1), body[0]) ||
                Program.contains(Program.wall.body, body[0]))
            {
                Console.Clear();
                Console.WriteLine("Game Over");
                Console.ReadKey();
            }
            // TODO: can snake eat?
            // TODO: check for collision with wall 
            // TODO: check for collision with itself (snake)
            // TODO: check for collision with border (console border (maximum width and height))
            // TODO: if necessary, load new level of the wall
        }

       
        public void Draw()
        {
            int i = 0;
            foreach(Point p in body)
            {
                Program.write(p.x, p.y, sign, (i++ == 0) ? ConsoleColor.Red : color);
            }
        }
    }
}
