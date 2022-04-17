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
        List<Customer> SearchByCountry(string country);

        List<Customer> SearchByCompanyName(string company);

        List<Customer> SearchByContactName(string contact);

    }
}