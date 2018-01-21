using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Convert.ToString(Console.ReadLine());
            string newpath = Convert.ToString(Console.ReadLine());
            string filename = Convert.ToString(Console.ReadLine());
            MinPrime(path, newpath, filename);
        }

        public static void MinPrime(string path, string newpath, string filename)
        {
            newpath = System.IO.Path.Combine(newpath, filename);
            System.IO.FileStream fs = System.IO.File.Create(newpath);
            fs.Close();
            System.IO.File.WriteAllText(newpath, GetMinPrime(path));

        }
        public static string GetMinPrime(string Path)
        {
            string[] text = System.IO.File.ReadAllLines(Path);
            int mn = 99999999;
            for (int j = 0; j < text.Length; ++j)
            {
                string[] s = text[j].Split(' ');
                for (int i = 0; i < s.Length; ++i)
                {
                    if (s[i] == "") continue;
                    int cur = Convert.ToInt32(s[i]);
                    if (!CheckPrime(cur)) continue;
                    if (cur < mn) mn = cur;
                }
            }
            return Convert.ToString(mn);
        }

        public static bool CheckPrime(int x) {
            if (x == 1) return false;
            for (int i = 2; i * i <= x; ++i) {
                if (x % i == 0) return false;
            }
            return true;
        }
    }
}
