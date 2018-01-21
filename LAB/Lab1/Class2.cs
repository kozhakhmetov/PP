using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Rectangle
    {
        public int h, w;
        public Rectangle(int _h = 0, int _w = 0) {
            h = _h;
            w = _w;
        }
        public int getArea() {
            return h * w;
        }
        public int getPerimeter() {
            return (h + w) * 2; 
        }
    }
}
