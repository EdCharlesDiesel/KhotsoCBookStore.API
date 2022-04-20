using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarPeace.Admin.Entities;
using StarPeace.Admin.Services;
using StarPeace.Admin.Contexts;

namespace StarPeace.Admin.Helpers
{
   public class DataImporterAdvanced:IDataImporter
    {
        readonly StarPeaceAdminDbContext _dbContext;
        public ActivityObserver(StarPeaceAdminDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
        }
        
        public IErrorLogger ErrorLogger { get; set; }

        public void Import(List<Customer> data)
        {

            try
            {
                foreach (var item in data)
                {
                    _dbContext.Customers.Add(item);
                    //some advanced things here
                }
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                ErrorLogger.Log(ex.Message);
            }            
        }
    }


}
