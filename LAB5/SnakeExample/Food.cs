﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeExample
{
    class Food
    {
        public Point location;
        public char sign;
        public ConsoleColor color;

        public Food()
        {
            sign = '@';
            color = ConsoleColor.Green;
            SetRandomPosition();
        }

        public void SetRandomPosition()
        {
            Program.score += 10;
            int x = new Random().Next(1, 69);
            int y = new Random().Next(1, 19);

            while(Program.wall.body.Contains(new Point(x, y)) || Program.snake.body.Contains(new Point(x, y)))
            {
                x = new Random().Next(1, 69);
                y = new Random().Next(1, 19);
            }
            location = new Point(x, y);
        }

        public void Draw()
        {
            Program.write(location.x, location.y, sign, color);
        }
    }
}
