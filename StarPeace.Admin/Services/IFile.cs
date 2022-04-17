using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace  StarPeace.Admin.Services
{
    public interface IUploadedFile
    {
        string FileName { get; set; }
        long Size { get; set; }
        string ContentType { get; set; }
        DateTime TimeStamp { get; set; }
        byte[] FileContent { get; set; }

        IUploadedFile Clone();
    }    
}
