using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarPeace.Admin.Services;
using StarPeace.Admin.Entities;
using StarPeace.Admin.Contexts;

namespace StarPeace.Admin.Helpers
{
    // public class DataImporterBasic : IDataImporter
    // {
    //     public IErrorLogger ErrorLogger { get; set; }

    //     public void Import(List<Customer> data)
    //     {
    //         using (StarPeaceAdminDbContext db = new StarPeaceAdminDbContext())
    //         {
    //             try
    //             {
    //                 foreach (var item in data)
    //                 {
    //                     db.Customers.Add(item);
    //                 }
    //                 db.SaveChanges();
    //             }
    //             catch(Exception ex)
    //             {
    //                 ErrorLogger.Log(ex.Message);
    //             }
    //         }
    //     }
    // }
}
