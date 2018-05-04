using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TotalCommander
{
    public class FolderContent
    {
        public ObservableCollection<Item> ContentList = new ObservableCollection<Item>();
        public string Path { get; set; }

        public FolderContent(string path)
        {
            Path = path;
        }

        public ObservableCollection<Item> GetContent()
        {
            ContentList.Clear();
            try
            {

                foreach (var dir in Directory.GetDirectories(Path).ToList())
            {
                
                    DirectoryInfo DI = new DirectoryInfo(dir);
                    ContentList.Add(new Item(DI.Name, "Directory", dir, DI.LastWriteTime, "FOLDER"));
            }
           

            string[] files = Directory.GetFiles(Path);
            foreach (var file in files)
            {

                FileInfo F = new FileInfo(file);
                ContentList.Add(new Item(F.Name, "File",Path + "\\" + F.Name, F.LastWriteTime, F.Extension));
               
            }
            return ContentList;
            }

            catch (UnauthorizedAccessException )
            {
                throw new Exception("AccessDenied"); 
            }

            
        }
    }
}
