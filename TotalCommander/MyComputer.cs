using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TotalCommander
{
    public static class MyComputer
    {
        public static List<RootFolder> GetDirectories()
        {
            List<RootFolder> RootDirectories = new List<RootFolder>();
            DriveInfo[] Drives = DriveInfo.GetDrives();
            foreach (var dr in Drives)
            {
                if (dr.DriveType.ToString()=="Fixed")
                {
                    RootDirectories.Add(new RootFolder("Local Disk " + dr.Name.Substring(0,1), dr.Name, "Assets/disc.png"));
                }
                
            }
            List<Environment.SpecialFolder> ListSF = new List<Environment.SpecialFolder>();
            ListSF.Add(Environment.SpecialFolder.Desktop);
            ListSF.Add(Environment.SpecialFolder.MyDocuments);
            ListSF.Add(Environment.SpecialFolder.Favorites);
            ListSF.Add(Environment.SpecialFolder.MyMusic);
            ListSF.Add(Environment.SpecialFolder.MyPictures);
            ListSF.Add(Environment.SpecialFolder.MyVideos);
            foreach (var sf in ListSF)
            {
                RootDirectories.Add(new RootFolder(sf.ToString(), Environment.GetFolderPath(sf), "Assets/blue_folder.png"));
            }
            return RootDirectories;

        }
        
    }
}
