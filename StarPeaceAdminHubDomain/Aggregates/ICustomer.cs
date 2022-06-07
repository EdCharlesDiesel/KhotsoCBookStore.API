using DDD.DomainLayer;
using StarPeaceAdminHubDomain.DTOs;
using System;

namespace StarPeaceAdminHubDomain.Aggregates
{
    public interface ICustomer : IEntity<int>
    {
        void FullUpdate(ICustomerFullEditDTO o);

        string FirstName { get; set; }

        string LastName { get; set; }

        int IdNumber { get; set; }

        string ContactTitle { get; set; }

        DateTime DateOfBirth { get; set; }

        string Address { get; set; }

        string City { get; set; }

        string Region { get; set; }

        string PostalCode { get; set; }

        string Country { get; set; }

        string Phone { get; set; }

        string MobileNumber { get; set; }


        // public IEnumerable<Orders> Orders { get; set; }
    }
}
