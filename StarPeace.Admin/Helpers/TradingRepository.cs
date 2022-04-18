using StarPeace.Admin.Contexts;
using StarPeace.Admin.Entities;
using StarPeace.Admin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeace.Admin.Helpers
{
    public class TradingRepository:ITradingRepository
    {
           readonly StarPeaceAdminDbContext _dbContext;
        public TradingRepository(StarPeaceAdminDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
        }
        public List<StockTradingEntry> SelectAll()
        {
            return _dbContext.StockTradingLogs.ToList();
        }

        public List<StockTradingEntry> SelectForUser(string user)
        {
            return _dbContext.StockTradingLogs.Where(i => i.UserName == user).ToList();
        }

        public void Insert(StockTradingEntry obj)
        {        
            _dbContext.StockTradingLogs.Add(obj);
            _dbContext.SaveChanges();            
        }

        public void Update(StockTradingEntry obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
