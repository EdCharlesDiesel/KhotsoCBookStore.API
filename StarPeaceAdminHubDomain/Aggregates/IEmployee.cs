using DDD.DomainLayer;
using StarPeaceAdminHubDomain.DTOs;
using System;

namespace StarPeaceAdminHubDomain.Aggregates
{
    public interface IEmployee : IEntity<int>
    {
        void FullUpdate(IEmployeeFullEditDTO o);

        string FirstName { get; set; }

        string LastName { get;}

        decimal BookStartPrice { get; set; }

        DateTime? StartPublishingDate { get;}
        
        DateTime? EndPublishingDate { get;  }

        int BookId { get; }        
    }    
}
