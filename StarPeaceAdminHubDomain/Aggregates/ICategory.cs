using DDD.DomainLayer;
using StarPeaceAdminHubDomain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarPeaceAdminHubDomain.Aggregates
{
    //It inherits from IEntity<int>, which furnishes all basic functionalities of aggregates.
    // • It has no Id property since it is inherited from IEntity<int>.
    // • All properties are read-only, and it has a FullUpdate method since all
    // aggregates can only be modified through update operations defined in the
    // user domain (in our case, the FullUpdate method).
    public interface ICategory : IEntity<int>
    {     
       string  CategoryName { get; set; }
       int BookId { get; }
       void FullUpdate(ICategoryFullEditDTO o);
        
    }    
}
