using DDD.DomainLayer;
using StarPeaceAdminHubDomain.DTOs;
using System;

namespace StarPeaceAdminHubDomain.Aggregates
{
    public interface IAuthor : IEntity<int>
    {
        void FullUpdate(IAuthorFullEditDTO o);

        string FirstName { get; set; }

        string LastName { get;}

        decimal BookStartPrice { get; set; }

        DateTime? StartPublishingDate { get;}
        
        DateTime? EndPublishingDate { get;  }

        int BookId { get; }        
    }    
}
