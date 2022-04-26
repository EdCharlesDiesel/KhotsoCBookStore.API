using DDD.DomainLayer;
using StarPeaceAdminHubDomain.Aggregates;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarPeaceAdminHubDB.Models
{
    public class CategoryEvent: Entity<long>, ICategoryEvent
    {
        public CategoryEventType Type { get; set; }
        public int CategoryId { get; set; }
        //public decimal NewPrice { get; set; }
        public string CategoryName { get; set; } 
        
        public long? OldVersion { get; set; }
        public long? NewVersion { get; set; }
    }
}
