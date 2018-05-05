using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Adilkhan\Desktop\New folder";
            DirectoryInfo d = new DirectoryInfo(path);
            foreach (FileInfo f in d.GetFiles()) {
                if (cont(f.FullName)) {
                    Console.WriteLine(f.Name);
                }
            }
            Console.ReadKey();
        }
        static bool cont(string path) {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            foreach (string s in sr.ReadLine().Split()) {
                if (isprime(int.Parse(s))) {
                    return true;
                }
            }
            return false;
        }
        static bool isprime(int x) {
            if (x == 1) return false;
            for (int i = 2; i * i <= x; ++i) {
                if (x % i == 0) return false;
            }
            return true;
        }
    }
}
