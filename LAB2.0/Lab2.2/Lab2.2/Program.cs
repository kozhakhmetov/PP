using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] First = Convert.ToString(Console.ReadLine()).Split('/');
            string[] Second = Convert.ToString(Console.ReadLine()).Split('/');
            Complex FirstComplex = new Complex(Convert.ToInt32(First[0]), Convert.ToInt32(First[1]));
            Complex SecondComplex = new Complex(Convert.ToInt32(Second[0]), Convert.ToInt32(Second[1]));
            Console.WriteLine(FirstComplex + SecondComplex);
        }
    }
}
