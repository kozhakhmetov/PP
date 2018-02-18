using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeExample
{
    [Serializable]
    class Player
    {
        public string name;
        public int score;
        public Player(string _name, int _score) {
            name = _name;
            score = _score;
        }
    }
}
