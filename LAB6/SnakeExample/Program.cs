using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Threading;

namespace SnakeExample
{
    class Program
    {
        static string[] menu = { "New Game", "Continue", "Leaderboards"};

        static int pos = 0;

        static List<Player> leaderboard = new List<Player>();

        static ConsoleKeyInfo btn;

        static void Main(string[] args)
        {
            leaderboard = GetLeaderboard();
            
            Menu();

            GameSave G = Get();

            if (pos == 0) G.Gameover = true;

            Game.Init(G);
            
            Game.Draw();

            Thread t = new Thread(Move);

            t.Start();
            
            while (!Game.Gameover)
            {
                btn = Console.ReadKey();

                if (btn.Key == ConsoleKey.F2)
                {
                    Save(new GameSave());
                    break;
                }

                if (btn.Key == ConsoleKey.UpArrow && Game.snake.dir != 2) Game.snake.dir = 4;
                if (btn.Key == ConsoleKey.DownArrow && Game.snake.dir != 4) Game.snake.dir = 2;
                if (btn.Key == ConsoleKey.LeftArrow && Game.snake.dir != 1) Game.snake.dir = 3;
                if (btn.Key == ConsoleKey.RightArrow && Game.snake.dir != 3) Game.snake.dir = 1;
            
            }

            t.Abort();

        }

        static void Move() {
            Game.snake.Draw();

            while (!Game.Gameover)
            {

                PrintScore();

                if (Game.snake.dir == 4) Game.snake.Move(0, -1);
                if (Game.snake.dir == 2) Game.snake.Move(0, 1);
                if (Game.snake.dir == 3) Game.snake.Move(-1, 0);
                if (Game.snake.dir == 1) Game.snake.Move(1, 0);

                if (Game.Gameover == true) break;
                
                Game.snake.Draw();

                
                if (Game.score >= 100 * Game.level * Game.level)
                {
                    Console.Clear();
                    Game.wall = new Wall();
                    Save(new GameSave());
                    Game.food = new Food();
                    Game.Draw();
                    Game.snake = new Snake();
                    Game.snake.speed = 200 - Game.level * 40;
                }
                Thread.Sleep(Game.snake.speed);
            }
            GameOver();
        }


        static void GameOver()
        {
            Console.Clear();
            Console.WriteLine("Game over press any key 2 times");
            Console.ReadKey();
            Console.WriteLine("Enter your name:");

            string name = Console.ReadLine();

            if (name.Length > 0)
            {
                leaderboard.Add(new Player(name, Game.score));
            }

            leaderboard.Sort((x, y) => x.score.CompareTo(y.score));

            ShowLeaderboard();

            SaveLeaderboard(leaderboard);
        }
        static void Menu()
        {
            while (true)
            {
                Console.Clear();
                for(int i = 0; i < menu.Length; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.BackgroundColor = (pos == i) ? ConsoleColor.DarkCyan : ConsoleColor.Black;
                    Console.WriteLine(menu[i]);
                }

                ConsoleKeyInfo btn = Console.ReadKey();
                if (btn.Key == ConsoleKey.UpArrow) pos = ((pos == 0) ? pos = 2 : pos - 1);
                if (btn.Key == ConsoleKey.DownArrow) pos = (pos + 1) % 3;
                if (btn.Key == ConsoleKey.Enter)
                {
                    if (pos != 2) break;
                    ShowLeaderboard();
                    while (Console.ReadKey().Key != ConsoleKey.Escape) ;
                }
            }
        }

        static void ShowLeaderboard() {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Name");
            Console.SetCursorPosition(25, 0);
            Console.WriteLine("Score");

            for (int i = leaderboard.Count - 1; i >= 0; --i)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(leaderboard[i].name);
                Console.SetCursorPosition(25, leaderboard.Count - i);
                Console.WriteLine(leaderboard[i].score);
            }
        }

        static void SaveLeaderboard(List<Player> lead)
        {
            FileStream fs = new FileStream(@"data2.ser", FileMode.Create, FileAccess.Write);
            BinaryFormatter xs = new BinaryFormatter();
            try
            {
                xs.Serialize(fs, lead);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                fs.Close();
            }
        }
        static List<Player> GetLeaderboard()
        {
            FileStream fs = new FileStream(@"data2.ser", FileMode.OpenOrCreate, FileAccess.Read);
            BinaryFormatter xs = new BinaryFormatter();
            List<Player> G = new List<Player>();
            try
            {
                G = (List<Player>)xs.Deserialize(fs);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                fs.Close();
            }
            return G;
        }

        static void Save(GameSave s)
        {
            FileStream fs = new FileStream(@"data1.ser", FileMode.Create, FileAccess.Write);

            BinaryFormatter xs = new BinaryFormatter();
            try
            {
                xs.Serialize(fs, s);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                fs.Close();
            }

        }

        static GameSave Get() {
            FileStream fs = new FileStream(@"data1.ser", FileMode.OpenOrCreate, FileAccess.Read);
            BinaryFormatter xs = new BinaryFormatter();
            GameSave G = new GameSave();
            try
            {
                G = (GameSave)xs.Deserialize(fs);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                fs.Close();
            }
            return G;
        }

        static void PrintScore()
        {
            Console.SetCursorPosition(0, 24);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Score:" + Convert.ToString(Game.score)); // Print score
            Console.WriteLine("Level:" + Convert.ToString(Game.level));
        }

        static public void DrawBorder()
        {
            for (int i = 0; i < 70; ++i)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(i, 20);
                Console.Write('-');
            }
        }
        
        static public void write(int x, int y, char sign, ConsoleColor c = ConsoleColor.White) // in position x and y print sign with color c
        {
            Console.ForegroundColor = c;
            Console.SetCursorPosition(x, y);
            Console.Write(sign);
        }
        static public bool contains(List<Point> a, Point b)  // Does the list a has Point b
        {
            foreach (Point p in a) if (p.x == b.x && p.y == b.y) return true;
            return false;
        }

    }
}
