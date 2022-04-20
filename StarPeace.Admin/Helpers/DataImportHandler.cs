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
        readonly StarPeaceAdminDbContext _dbContext;
        public ActivityObserver(StarPeaceAdminDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
        }

        public void Process(string filename, string filecontent)
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
                _dbContext.Customers.Add(obj);
            }
            _dbContext.SaveChanges();
            

            if (NextHandler != null)
            {
                NextHandler.Process(filename, filecontent);
            }
        }
    }
}
