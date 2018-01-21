using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Circle
    {
        double pi = Math.PI;
        public double r = 0;
        public Circle(double r = 0) {
            this.r = r;      
        }
        public double Getarea() {
            return r * r * pi;
        }
        public double GetDiameter() {
            return r * 2;
        }
        public double Getcircumference() {
            return r * 2 * pi;
        }
    }
}
