using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;


namespace StarPeace.Admin.Helpers
{
    public class OleDbFactory : IDatabaseFactory
    {
        public DbConnection GetConnection()
        {
            return new OleDbConnection();
        }

        public DbCommand GetCommand()
        {
            return new OleDbCommand();
        }

        public DbParameter GetParameter()
        {
            return new OleDbParameter();
        }
    }
}
