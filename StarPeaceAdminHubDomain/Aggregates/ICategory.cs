using DDD.DomainLayer;
using StarPeaceAdminHubDomain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarPeaceAdminHubDomain.Aggregates
{
    public interface ICategory : IEntity<int>
    {     
       string  CategoryName { get; set; }
       int BookId { get; }
       void FullUpdate(ICategoryFullEditDTO o);
        
    }    
}
