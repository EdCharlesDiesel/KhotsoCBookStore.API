using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using StarPeace.Admin.Services;

namespace StarPeace.Admin.Helpers
{
    public class FileFormatHandler : IHandler
    {
        public IHandler NextHandler { get; set; }

        public void Process(string filename, string filecontent)
        {
            string ext = Path.GetExtension(filename);
            if (ext != ".txt" && ext == ".csv")
            {
                throw new Exception("Invalid file type!");
            }
            else
            {
                string[] records = filecontent.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                if (records == null || records.Length == 0)
                {
                    throw new Exception("Invalid data!");
                }
                else
                {
                    string[] cols = records[0].Split(',');
                    if (cols.Length != 5)
                    {
                        throw new Exception("Missing or incomplete data!");
                    }
                }
            }

            if (NextHandler != null)
            {
                NextHandler.Process(filename, filecontent);
            }
        }
    }
}
