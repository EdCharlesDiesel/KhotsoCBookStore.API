using DDD.DomainLayer;
using StarPeaceAdminHubDomain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarPeaceAdminHubDomain.Aggregates
{
    public interface ICategory : IEntity<int>
    {
        void FullUpdate(ICategoryFullEditDTO o);
            
       string  CategoryName { get; set; }
       int BookId { get; }
        
    }

    
}
