using DDD.DomainLayer;
using StarPeaceAdminHubDomain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarPeaceAdminHubDomain.Aggregates
{
    public interface ICategory : IEntity<Guid>
    {
        void FullUpdate(ICategoryFullEditDTO o);
        
       string  CategoryName { get; set; }
        // string Name { get; set; }

        // string Description { get;}
        // decimal Price { get; set; }
        // int DurationInDays { get; }
        // DateTime? StartValidityDate { get;}
        // DateTime? EndValidityDate { get;  }
        Guid BookId { get; }
        
    }

    
}
