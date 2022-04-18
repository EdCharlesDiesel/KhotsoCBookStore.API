using StarPeace.Admin.Entities;
using StarPeace.Admin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeace.Admin.Helpers
{
    public class DataImportHandler : IHandler
    {
        public IHandler NextHandler { get; set; }

        public void Process(string filename, string filecontent)
        {
            using (AppDbContext db = new AppDbContext())
            {
                string[] records = filecontent.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string record in records)
                {
                    string[] cols = record.Split(',');
                    Customer obj = new Customer();
                    obj.CustomerID = cols[0];
                    obj.CompanyName = cols[1];
                    obj.ContactName = cols[2];
                    obj.Phone = cols[3];
                    obj.Location = cols[4];
                    db.Customers.Add(obj);
                }
                db.SaveChanges();
            }

            if (NextHandler != null)
            {
                NextHandler.Process(filename, filecontent);
            }
        }
    }
}
