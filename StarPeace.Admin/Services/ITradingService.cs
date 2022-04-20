using StarPeace.Admin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarPeace.Admin.Helpers;

namespace StarPeace.Admin.Services
{
    public interface ITradingService
    {
        bool Buy(BuySellDetails obj);
        bool Sell(BuySellDetails obj);
        List<StockTradingEntry> GetAllTradingLog();
        List<StockTradingEntry> GetTradingLogForUser(string user);
    }
}
