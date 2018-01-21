using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2._3
{
    class Dir
    {
        public DirectoryInfo dir;
        public int len;
        public Dir(DirectoryInfo _dir, int _len) {
            len = _len;
            dir = _dir;
        }
    }
}
