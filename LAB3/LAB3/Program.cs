using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFarManager
{
    class Program
    {

        static void showState(DirectoryInfo cur, int pos)
        {
            FileSystemInfo[] infos = cur.GetFileSystemInfos();

            for (int i = 0; i < infos.Length; i++)
            {
                Console.BackgroundColor = i == pos ? ConsoleColor.White : ConsoleColor.Black;

                Console.ForegroundColor = infos[i].GetType() == typeof(DirectoryInfo) ? ConsoleColor.Magenta : ConsoleColor.Green;

                Console.WriteLine(infos[i].Name);
            }
        }

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            int pos = 0;

            DirectoryInfo dir = new DirectoryInfo(@"C:\test");

            while (true)
            {
                Console.Clear();
                showState(dir, pos);

                ConsoleKeyInfo btn = Console.ReadKey();
                switch (btn.Key)
                {
                    case ConsoleKey.UpArrow:
                        pos--;
                        if (pos < 0)
                            pos = dir.GetFileSystemInfos().Length - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        pos++;
                        pos %= dir.GetFileSystemInfos().Length;
                        break;
                    case ConsoleKey.Enter:
                        FileSystemInfo f = dir.GetFileSystemInfos()[pos];
                        if (f.GetType() == typeof(DirectoryInfo))
                        {
                            dir = new DirectoryInfo(f.FullName);
                            pos = 0;
                        }
                        else
                        {
                            Process.Start(f.FullName);
                        }
                        break;
                    case ConsoleKey.Escape:
                        pos = 0;
                        dir = dir.Parent;
                        break;
                }
            }
        }
    }
}