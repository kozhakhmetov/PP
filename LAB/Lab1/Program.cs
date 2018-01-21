using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arg = Convert.ToString(Console.ReadLine()).Split(' ');
            for (int i = 0; i < arg.Length; ++i) {
                if (check(Convert.ToInt32(arg[i]))) {
                    Console.WriteLine(arg[i]);
                }
            }
            Console.ReadKey();
        }
        public static bool check(int x) {
            if (x == 1) return false;
            for (int i = 2; i * i <= x; ++i) {
                if (x % i == 0) return false;
            }
            return true;
        }
    }
}
