using DDD.DomainLayer;
using StarPeaceAdminHubDomain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarPeaceAdminHubDomain.Aggregates
{
    public interface IBook: IEntity<int>
    {        
        string Title { get; set; }

        string ISBN { get; set; }

        string Description {get;set;}
        
        DateTime PublishingDate { get; set; }
        
        decimal Cost { get; set; }    

        decimal RetailPrice { get; set; }     
        
        string CoverFileName { get; set; } 

        void FullUpdate(IBookFullEditDTO o);        
    }
}
