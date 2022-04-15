using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using StarPeace.Admin.Services;

namespace StarPeace.Admin.Helpers
{

    public class TextFileErrorLogger : IErrorLogger
    {
        public void Log(string msg)
        {
            msg += $" [{DateTime.Now}]";
            msg += "\r\n";
            File.AppendAllText(AppSettings.LogFileFolder + "/errorlog.txt", msg);
        }
    }

    public class XmlErrorLogger : IErrorLogger
    {
        public void Log(string msg)
        {
            msg = $"<error><message>{msg}</message><timestamp>{DateTime.Now}</timestamp></error>";
            File.AppendAllText(AppSettings.LogFileFolder + "/errorlog.xml", msg);
        }
    }

}
