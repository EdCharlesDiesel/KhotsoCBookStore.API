using System;

namespace StarPeaceAdminHubDomain.DTOs
{
    public interface IEmployeeFullEditDTO
    {
        int EmployeeId { get; set; }
 
        string LastName { get; set; }

        string FirstName { get; set; }

        string Title { get; set; }

        string TitleOfCourtesy { get; set; }
        
        int IdNumber { get; set; }

        DateTime? BirthDate { get; set; }

        DateTime? HireDate { get; set; }

        string Address { get; set; }

        string City { get; set; }

        string Region { get; set; }

        string PostalCode { get; set; }

        string Country { get; set; }

        string HomePhone { get; set; }

        string Extension { get; set; }

        byte[] Photo { get; set; }

        string Notes { get; set; }

        int? ReportsTo { get; set; }

        string PhotoPath { get; set; }

    }
}
