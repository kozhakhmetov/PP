using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Convert.ToString(Console.ReadLine());
            Console.WriteLine(GetMaxMin(path));
        }
        public static string GetMaxMin(string path)
        {
            return GetMax(path) + " " + GetMin(path);
        }
        public static string GetMax(string Path)
        {
            string[] text = System.IO.File.ReadAllLines(Path);
            int mx = -99999999;
            for (int j = 0; j < text.Length; ++j)
            {
                string[] s = text[j].Split(' ');
                for (int i = 0; i < s.Length; ++i)
                {
                    if (s[i] == "") continue;
                    int cur = Convert.ToInt32(s[i]);
                    if (cur > mx) mx = cur;
                }
            }
            return Convert.ToString(mx);
        }
        public static string GetMin(string Path)
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
                    if (cur < mn) mn = cur;
                }
            }
            return Convert.ToString(mn);
        }
    }
}
