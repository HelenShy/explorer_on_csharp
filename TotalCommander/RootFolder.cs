using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalCommander
{
    public class RootFolder 
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string IconPath { get; set; }
        public RootFolder(string name, string path, string iconPath)
        {
            Name = name;
            Path = path;
            IconPath = iconPath;
        }
    }
}
