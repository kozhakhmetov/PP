using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeExample
{
    class Game
    {
        static public Snake snake;
        static public Wall wall;
        static public Food food;
        static public int score;
        static public int level;
        static public bool Gameover;
        static public void Init(GameSave G)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(70, 27);
            if (G.Gameover == false)
            {
                food = G.food;
                score = G.score;
                level = G.level;
                snake = G.snake;
                wall = G.wall;
                Gameover = G.Gameover;
            }
            else
            {
                score = 0;
                Gameover = false;
                level = 0;
                snake = new Snake();
                wall = new Wall();
                food = new Food();
            }
        }

        static public void initfrom(GameSave G) {
            food = G.food;
            score = G.score;
            level = G.level;
            snake = G.snake;
            wall = G.wall;
            Gameover = G.Gameover;
        }

        static public void Draw() {
            Console.Clear();
            wall.Draw();
            food.Draw();
            Program.DrawBorder();
        }
    }
}
