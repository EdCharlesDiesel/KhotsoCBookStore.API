using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace StarPeace.Admin.Helpers
{
    public class ReportGenerator
    {
        Lazy<CustomerData> lazyObj = new Lazy<CustomerData>();

        public void GenerateCustomerReport()
        {
            CustomerData data = lazyObj.Value;
            //use data to generate report
        }

        public void GenerateOrderHistoryReport()
        {
            CustomerData data = lazyObj.Value;
            //use data to generate report
        }

        public void GenerateEmployeeReport()
        {
            //no need of Customer data
            //generate employee report
        }

    }
}
