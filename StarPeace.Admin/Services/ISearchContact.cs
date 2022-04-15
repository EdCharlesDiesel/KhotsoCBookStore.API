using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using StarPeace.Admin.Entities;

namespace StarPeace.Admin.Services
{
    public interface ISearchContact
    {
        public static List<Customer> SearchByCountry(string country);

        public static List<Customer> SearchByCompanyName(string company);

        public static List<Customer> SearchByContactName(string contact);

    }
}