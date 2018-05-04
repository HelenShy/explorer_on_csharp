using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalCommander
{
    public class Item
    {
        private Dictionary<string, string> Extentions = new Dictionary<string, string>
        {
            [".PNG"] = "Image",
            [".JPG"] = "Image",
            [".JPEG"] = "Image",
            [".BMP"] = "Image",
            [".GIF"] = "Image",
            [".MP3"] = "Music",
            [".AVI"] = "Video",
            [".MP4"] = "Video",
            [".RAR"] = "Archive",
            [".ZIP"] = "Archive",
            [".PDF"] = "PDF",
            [".HTML"] = "Browser",
            ["FOLDER"] = "Folder"
        };
        private Dictionary<string, string> MediaIcons = new Dictionary<string, string>
        {
            ["Image"] = "Assets/image.png",
            ["Music"] = "Assets/music.png",
            ["Video"] = "Assets/video.png",
            ["Archive"] = "Assets/archive.png",
            ["Folder"] = "Assets/folder.png",
            ["PDF"] = "Assets/PDF.png",
            ["Browser"] = "Assets/browser.png",
        };

        public string Name { get; set; }
        public string Type { get; set; }
        public string Path { get; set; }
        public DateTime DateModified { get; set; }
        public string IconPath { get; set; }

        public Item(string name, string type,string path, DateTime dateModified, string extention)
        {
            Name = name;
            Type = type;
            Path = path;
            DateModified = dateModified;
            IconPath = GetIcon(extention.ToUpper());
        }

        public string GetIcon(string extention)
        {

            if (Extentions.ContainsKey(extention))
            {
                return MediaIcons[Extentions[extention]];
            }
            return "Assets/document.png";
        }
    }
}
