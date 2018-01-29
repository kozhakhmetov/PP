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

            Stack<Dir> St = new Stack<Dir>();

            St.Push(new Dir(path, 0, false));

            while (St.Count > 0) {
                Dir cur = St.Pop();
                Console.WriteLine(cur);

                if (cur.flag == true) continue;

                foreach (FileInfo i in new DirectoryInfo(cur.Path).GetFiles()) {
                    St.Push(new Dir(i.FullName, cur.len + 5, true));
                }
                foreach (DirectoryInfo i in new DirectoryInfo(cur.Path).GetDirectories()) {
                    St.Push(new Dir(i.FullName, cur.len + 5, false));
                }

            }
        }
    }
}
