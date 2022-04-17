using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeace.Extensions.Service.Helpers
{
    public class AppSettings
    {
        public static string ConnectionString { get; set; }
        public static string Factory { get; set; }
        public static string FactoryType { get; set; }
    }
}
