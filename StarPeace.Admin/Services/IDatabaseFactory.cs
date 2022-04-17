using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;

namespace StarPeace.Admin.Services
{
    public interface IDatabaseFactory
    {
        DbConnection GetConnection();
        DbCommand GetCommand();
        DbParameter GetParameter();
    }
}
