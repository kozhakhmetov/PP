using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2._2
{
    class Complex
    {
        public int a, b;
        public Complex(int _a = 0, int _b = 0)
        {
            a = _a;
            b = _b;
        }
        public static Complex operator +(Complex c1, Complex c2)
        {
            Complex c3 = new Complex();
            c3.b = lcm(c1.b, c2.b);
            c3.a = ((c3.b / c1.b) * c1.a) + (c2.a * (c3.b / c2.b));
            int Gcd = gcd(c3.a, c3.b);
            c3.a /= Gcd;
            c3.b /= Gcd;
            return c3;
        }
        public override string ToString()
        {
            return Convert.ToString(a) + '/' + Convert.ToString(b);
        }
        public static int lcm(int a, int b)
        {
            return (a * b) / gcd(a, b);
        }
        public static int gcd(int a, int b)
        {
            return b == 0 ? a : gcd(b, a % b);
        }
    }
}
