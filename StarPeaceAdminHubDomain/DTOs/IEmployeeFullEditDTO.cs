using System;

namespace StarPeaceAdminHubDomain.DTOs
{
    public interface IEmployeeFullEditDTO
    {
        int Id { get; set; }
 
        string FirstName { get; set; }

        string LastName { get; set;}

        int IdNumber { get; set; }

        DateTime StartOfEmployment { get; set;}
        
        DateTime? EndOfEmployement { get; set; }

    }
}
