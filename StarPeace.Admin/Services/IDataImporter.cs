using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarPeace.Admin.Services;
using StarPeace.Admin.Entities;


namespace StarPeace.Admin.Services
{
    public interface IDataImporter
    {
        IErrorLogger ErrorLogger { get; set; }
        void Import(List<Customer> data);
    }
}
