using System;

namespace StarPeaceAdminHubDomain.DTOs
{
    public interface ICustomerFullEditDTO
    {
        int CustomerId { get; set; }

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

    }
}
