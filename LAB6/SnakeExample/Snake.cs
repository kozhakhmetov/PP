using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeExample
{
    [Serializable]
    class Snake
    {
        public List<Point> body;
        public char sign;
        public ConsoleColor color;
        public int speed;
        public int dir;

        public Snake() {
            sign = 'o';
            color = ConsoleColor.Yellow;
            body = new List<Point>();
            speed = 200;
            dir = 2;

            body.Add(new Point(0, 2));
            body.Add(new Point(0, 1));
            body.Add(new Point(0, 0));

        }

        public void Move(int dx, int dy) {

            Program.write(body[body.Count - 1].x, body[body.Count - 1].y, ' '); // print an empty space instead of the last element of the snake
            
            body.Insert(0, new Point(body[0].x + dx, body[0].y + dy)); //  insert a new head
            
            if (body[0].x < 0) body[0].x = 69; // check for borders
            if (body[0].x > 69) body[0].x = 0;
            if (body[0].y < 0) body[0].y = 19;
            if (body[0].y > 19) body[0].y = 0;

            if (Game.food.location.x != body[0].x || Game.food.location.y != body[0].y) // does the snake eat the food
            {
                body.RemoveAt(body.Count - 1); // remove the last element of the snake
            }
            else
            {
                Game.score += Game.food.cost;
                Game.food.SetRandomPosition();   // set new position for the food
                Game.food.Draw();
            }

            if (Program.contains(Game.snake.body.GetRange(1, body.Count - 1), body[0]) ||  // check for collision with wall or the snake itself
                Program.contains(Game.wall.body, body[0]))
            {
                Game.Gameover = true;
            }
        }

       
        public void Draw()    /// Draw the body of the snake
        {
            int i = 0;
            foreach(Point p in body)
            {
                Program.write(p.x, p.y, sign, (i++ == 0) ? ConsoleColor.Red : color);
            }
        }
    }
}
