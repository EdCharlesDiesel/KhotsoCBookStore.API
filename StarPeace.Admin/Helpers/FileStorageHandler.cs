using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using StarPeace.Admin.Services;
using StarPeace.Admin.Entities;
using StarPeace.Admin.Contexts;

namespace StarPeace.Admin.Helpers
{
    public class FileStorageHandler : IHandler
    {
        public IHandler NextHandler { get; set; }
        readonly StarPeaceAdminDbContext _dbContext;
        public FileStorageHandler(StarPeaceAdminDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
        }

        public void Process(string filename, string filecontent)
        {
            filename = AppSettings.StoragePath + "\\" + Path.GetFileNameWithoutExtension(filename) + DateTime.Now.ToString("yyyy-MM-dd") + Path.GetExtension(filename);
            System.IO.File.AppendAllText(filename, filecontent);
        
            FileStoreEntry fse = new FileStoreEntry();
            fse.FileName = filename;
            fse.UploadedOn = DateTime.Now;
            _dbContext.FileStores.Add(fse);
            _dbContext.SaveChanges();
            

            if (NextHandler != null)
            {
                NextHandler.Process(filename, filecontent);
            }
        }
    }
}
