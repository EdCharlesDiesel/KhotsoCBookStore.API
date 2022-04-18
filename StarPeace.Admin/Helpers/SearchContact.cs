using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarPeace.Admin.Entities;
using StarPeace.Admin.Contexts;
using StarPeace.Admin.Services;

namespace StarPeace.Admin.Helpers
{
    // public class SearchContact: ISearchContact
    // {
    //  public static List<Customer> SearchByCountry(string country)
    //     {
    //         using (StarPeaceAdminDbContext db = new StarPeaceAdminDbContext())
    //         {
    //             var query = from c in db.Customers
    //                         where c.Country.Contains(country)
    //                         orderby c.CustomerID ascending
    //                         select c;
    //             return query.ToList();
    //         }
    //     }

    //     public static List<Customer> SearchByCompanyName(string company)
    //     {
    //         using (StarPeaceAdminDbContext db = new StarPeaceAdminDbContext())
    //         {
    //             var query = from c in db.Customers
    //                         where c.CompanyName.Contains(company)
    //                         orderby c.CustomerID ascending
    //                         select c;
    //             return query.ToList();
    //         }
    //     }

    //     public static List<Customer> SearchByContactName(string contact)
    //     {
    //         using (StarPeaceAdminDbContext db = new StarPeaceAdminDbContext())
    //         {
    //             var query = from c in db.Customers
    //                         where c.ContactName.Contains(contact)
    //                         orderby c.CustomerID ascending
    //                         select c;
    //             return query.ToList();
    //         }
    //     }

    //}
}