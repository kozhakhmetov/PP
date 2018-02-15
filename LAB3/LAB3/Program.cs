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
        static int n = 0;
        static void ShowState(string path, int pos, bool flag)
        {
            Console.Clear();
            if (flag == true)
            {
                DirectoryInfo cur = new DirectoryInfo(path);
                FileSystemInfo[] infos = cur.GetFileSystemInfos();
                for (int i = 0; i < infos.Length; i++)
                {
                    Console.BackgroundColor = i == pos ? ConsoleColor.White : ConsoleColor.Black;
                    Console.ForegroundColor = infos[i].GetType() == typeof(DirectoryInfo) ? ConsoleColor.Magenta : ConsoleColor.Green;
                    Console.WriteLine(infos[i].Name);
                }
                n = infos.Length; 
            }
            else
            {
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                StreamReader sw = new StreamReader(fs);
                Console.WriteLine(sw.ReadToEnd());
                sw.Close();
                fs.Close();
            }
        }
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            int pos = 0;
            string path = @"C:\Users\Adilkhan\Desktop\test";
            bool flag = true;

            while (true)
            {
                ShowState(path, pos, flag);
                ConsoleKeyInfo btn = Console.ReadKey();
                if (btn.Key == ConsoleKey.UpArrow)
                {
                    pos = (pos == 0) ? n - 1 : pos - 1;
                }
                else if (btn.Key == ConsoleKey.DownArrow)
                {
                    pos = (pos + 1) % n;
                }
                else if (btn.Key == ConsoleKey.Enter && flag == true)
                {

                    FileSystemInfo f = new DirectoryInfo(path).GetFileSystemInfos()[pos];
                    path = f.FullName;
                    pos = 0;
                    flag = (f.GetType() == typeof(DirectoryInfo)) ? true : false;
                }
                else if (btn.Key == ConsoleKey.Escape)
                {
                    pos = 0;
                    flag = true;
                    int id = path.Length - 1;
                    while (path[id] != Convert.ToChar(92)) id--;
                    path = path.Remove(id);
                }
            }
        }
    }
}