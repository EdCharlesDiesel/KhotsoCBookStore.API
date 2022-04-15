﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeace.Admin.Helpers
{
    public class AppSettings
    {
        public static string ConnectionString { get; set; }
        public static string Factory { get; set; }
        public static string FactoryType { get; set; }
       public static string LogFileFolder { get; set; } 

        public static string MenuFilePath { get; set; }
    }
}
