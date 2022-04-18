using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using StarPeace.Admin.Services;

namespace StarPeace.Admin.Helpers
{
    public class GZipAlgorithm : ICompressionAlgorithm
    {
        public void Compress(string source, string destination)
        {
            using (FileStream originalFileStream = File.OpenRead(source))
            {
                using (FileStream compressedFileStream = File.Create(destination))
                {
                    using (GZipStream compressionStream = new GZipStream(compressedFileStream, CompressionMode.Compress))
                    {
                        originalFileStream.CopyTo(compressionStream);
                    }
                }
            }
        }
    }
}
