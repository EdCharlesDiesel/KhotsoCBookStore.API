using DDD.DomainLayer;
using StarPeaceAdminHubDomain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarPeaceAdminHubDomain.Aggregates
{
    public interface IBook : IEntity<int>
    {
        void FullUpdate(IBookFullEditDTO o);
        string Name { get; set; }

        string Description { get;}
        decimal Price { get; set; }
        int DurationInDays { get; }
        DateTime? StartValidityDate { get;}
        DateTime? EndValidityDate { get;  }
        int DestinationId { get; }
        
    }

    
}
