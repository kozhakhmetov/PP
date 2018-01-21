using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2._3
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Convert.ToString(Console.ReadLine());
            DirectoryInfo dr = new DirectoryInfo(path);
            Stack<Dir> St = new Stack<Dir>();
            St.Push(new Dir(dr, 0));

            while (St.Count() > 0) {

                Dir cur = St.Pop();

                foreach (DirectoryInfo i in cur.dir.GetDirectories()) {
                    Console.WriteLine(new string(' ', cur.len) + i.Name);
                    St.Push(new Dir(i, cur.len + 5));
                }

                foreach (FileInfo i in cur.dir.GetFiles()) {
                    Console.WriteLine(new string(' ', cur.len) + i.Name);
                }
            }
        }
    }
}
