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
        public string Path;
        public int len;
        public bool flag;
        public Dir(string _Path, int _len, bool _flag = false) {
            Path = _Path;
            len = _len;
            flag = _flag;
        }
        public override string ToString()
        {
            string ans = new string(' ', len);
            if (!flag) ans += new DirectoryInfo(Path).Name;
            else ans += new FileInfo(Path).Name;
            return ans;
        }
    }
}
