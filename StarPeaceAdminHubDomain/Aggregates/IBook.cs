using DDD.DomainLayer;
using StarPeaceAdminHubDomain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarPeaceAdminHubDomain.Aggregates
{
    public interface IBook: IEntity<int>
    {        
        public string Title { get; set; }

        public string ISBN { get; set; }
        
        DateTime PublishingDate { get; set; }
        
        decimal Cost { get; set; }    

        decimal RetailPrice { get; set; }     
        
        string CoverFileName { get; set; } 

        void FullUpdate(IBookFullEditDTO o);        
    }
}
