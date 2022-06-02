using DDD.DomainLayer;
using StarPeaceAdminHubDomain.DTOs;
using System;

namespace StarPeaceAdminHubDomain.Aggregates
{
    public interface ICustomer : IEntity<int>
    {
        void FullUpdate(ICustomerFullEditDTO o);

        string FirstName { get; set; }

        string LastName { get;}

        decimal BookStartPrice { get; set; }

        DateTime? StartPublishingDate { get;}
        
        DateTime? EndPublishingDate { get;  }

        int BookId { get; }        
    }    
}
