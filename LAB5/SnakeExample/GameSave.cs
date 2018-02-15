using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeExample
{
    [Serializable]
    class GameSave
    {
        public Snake snake;
        public Wall wall;
        public Food food;
        public int score;
        public int level;
        public bool Gameover;

        public GameSave() {
            snake = Game.snake;
            wall = Game.wall;
            food = Game.food;
            Gameover = Game.Gameover;
            level = Game.level;
            score = Game.score;
        }
    }
}
