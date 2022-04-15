using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using StarPeace.Admin.Entities;

namespace StarPeace.Admin.Helpers
{
    public class DataExporter
    {
         public static string ExportToCSV(List<Customer> data)
        {
            StringBuilder sb = new StringBuilder();
            foreach(var item in data)
            {
                sb.AppendFormat("{0},{1},{2},{3}", item.CustomerID, item.CompanyName, item.ContactName, item.Country);
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public static string ExportToXML(List<Customer> data)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<customers>");
            foreach (var item in data)
            {
                sb.AppendFormat("<customer><customerID>{0}</customerID>,<companyName>{1}</companyName>,<contactName>{2}</contactName>,<country>{3}</country></customer>", item.CustomerID, item.CompanyName, item.ContactName, item.Country);
                sb.AppendLine();
            }
            sb.AppendLine("</customers>");
            return sb.ToString();
        }

        public static string ExportToPDF(List<Customer> data)
        {
            throw new NotImplementedException();
        }
    }
}