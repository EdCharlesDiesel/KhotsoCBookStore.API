using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using StarPeace.Admin.Services;


namespace StarPeace.Admin.Helpers
{
    public class DeflateAlgorithm : ICompressionAlgorithm
    {
        public void Compress(string source, string destination)
        {
            using (FileStream originalFileStream = File.OpenRead(source))
            {
                using (FileStream compressedFileStream = File.Create(destination))
                {
                    using (DeflateStream compressionStream = new DeflateStream(compressedFileStream, CompressionMode.Compress))
                    {
                        originalFileStream.CopyTo(compressionStream);
                    }
                }
            }
        }
    }
}
