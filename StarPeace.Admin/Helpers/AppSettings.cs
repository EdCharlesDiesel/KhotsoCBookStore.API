using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeace.Admin.Helpers
{
    public class AppSettings
    {
        public static string ConnectionString { get; set; }
        public static string StoragePath { get; set; }
        public static string SourceFolder { get; set; }
        public static string DestinationFolder { get; set; }        
    }
}
