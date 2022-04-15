﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeace.Extensions.Service.Helpers
{
    public class DataImporterBasic : IDataImporter
    {
        public IErrorLogger ErrorLogger { get; set; }

        public void Import(List<Customer> data)
        {
            using (AppDbContext db = new AppDbContext())
            {
                try
                {
                    foreach (var item in data)
                    {
                        db.Customers.Add(item);
                    }
                    db.SaveChanges();
                }
                catch(Exception ex)
                {
                    ErrorLogger.Log(ex.Message);
                }
            }
        }
    }
}
