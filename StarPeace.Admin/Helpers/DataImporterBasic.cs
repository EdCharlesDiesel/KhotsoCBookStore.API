using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarPeace.Admin.Services;
using StarPeace.Admin.Entities;
using StarPeace.Admin.Contexts;

namespace StarPeace.Admin.Helpers
{
    public class DataImporterBasic : IDataImporter
    {
        public IErrorLogger ErrorLogger { get; set; }
        readonly StarPeaceAdminDbContext _dbContext;
        public DataImporterBasic(StarPeaceAdminDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
        }

        public void Import(List<Customer> data)
        {

            try
            {
                foreach (var item in data)
                {
                    _dbContext.Customers.Add(item);
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
