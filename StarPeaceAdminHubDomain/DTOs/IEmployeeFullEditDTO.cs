using System;

namespace StarPeaceAdminHubDomain.DTOs
{
    public interface IEmployeeFullEditDTO
    {
        int Id { get; set; }
 
        string FirstName { get; set; }

        string LastName { get;}

        string IdNumber { get; set; }

        decimal BookStartPrice { get; set; }

        DateTime BeginingOfEmployement { get;}
        
        DateTime? EndOfEmployement { get;  }

        //int BookId { get; }
    }
}
