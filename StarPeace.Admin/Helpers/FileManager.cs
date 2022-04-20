using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StarPeace.Admin.Helpers
{
    public class FileManager
    {
        private string basePath;

        public FileManager(string basepath)
        {
            this.basePath = basepath;
        }

        public void CreateFolder(string location)
        {
            Directory.CreateDirectory(basePath + "\\" + location);
        }

        public void CopyFiles(string sourceFolder,string destinationFolder,string pattern)
        {
            sourceFolder = basePath + "\\" + sourceFolder;
            destinationFolder = basePath + "\\" + destinationFolder;

            string[] files = Directory.GetFiles(sourceFolder,pattern);

            foreach(string source in files)
            {
                string destination = destinationFolder + "\\" + Path.GetFileName(source);
                File.Copy(source, destination);
            }
        }

        public void DeleteFiles(string location,string pattern)
        {
            location = basePath + "\\" + location;
            string[] files = Directory.GetFiles(location, pattern);
            foreach (string file in files)
            {
                File.Delete(file);
            }
        }
    }
}
