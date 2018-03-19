using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SnakeExample
{
    class Program
    {
        static string[] menu = { "New Game", "Continue", "Leaderboards"};

        static int pos = 0;

        static List<Player> leaderboard = new List<Player>();

        static void Main(string[] args)
        {
            leaderboard = GetLeaderboard();

            
            Menu();

            GameSave G = Get();

            if (pos == 0) G.Gameover = true;

            Game.Init(G);
            
            Game.Draw();
            
            while (!Game.Gameover)
            {
                Game.snake.Draw();
                PrintScore();
                
                ConsoleKeyInfo btn = Console.ReadKey();

                if (btn.Key == ConsoleKey.F2)
                    Save(new GameSave());

                if (btn.Key == ConsoleKey.UpArrow) Game.snake.Move(0, -1);
                if (btn.Key == ConsoleKey.DownArrow) Game.snake.Move(0, 1);
                if (btn.Key == ConsoleKey.LeftArrow) Game.snake.Move(-1, 0);
                if (btn.Key == ConsoleKey.RightArrow) Game.snake.Move(1, 0);

                if (Game.score >= 100 * Game.level)
                {
                    Console.Clear();
                    Game.wall = new Wall();
                    Game.Draw();
                    Game.snake = new Snake();
                }
                
 
            }

            GameOver();

            Console.ReadKey();

        }


        static void GameOver()
        {
            Console.Clear();
            Console.WriteLine("Enter your name");

            string name = Console.ReadLine();
            leaderboard.Add(new Player(name, Game.score));

            leaderboard.Sort((x, y) => x.score.CompareTo(y.score));

            ShowLeaderboard();

            SaveLeaderboard(leaderboard);
        }
        static void Menu() {
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
