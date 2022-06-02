using DDD.DomainLayer;
using StarPeaceAdminHubDomain.DTOs;
using System;

namespace StarPeaceAdminHubDomain.Aggregates
{
    public interface IMemberOrder : IEntity<int>
    {
        void FullUpdate(IMemberOrderFullEditDTO o);

        string FirstName { get; set; }

        string LastName { get;}

        decimal BookStartPrice { get; set; }

        DateTime? StartPublishingDate { get;}
        
        DateTime? EndPublishingDate { get;  }

        int BookId { get; }        
    }    
}
