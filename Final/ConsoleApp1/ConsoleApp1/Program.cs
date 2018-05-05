using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberofpoly = 0, numberofwords = 0;
            foreach (string s in Console.ReadLine().Split(' ')) {
                if (ispoly(s)) {
                    numberofpoly++;
                }
                numberofwords++;
            }
            Console.WriteLine(numberofwords);
            Console.WriteLine(numberofpoly);
            Console.ReadKey();
        }
        static public bool ispoly(string s) {
            for(int i = 0; i < s.Length / 2; ++i)
            {
                if (s[i] != s[s.Length - i - 1]) return false;
            }
            return true;
        }
    }
}
