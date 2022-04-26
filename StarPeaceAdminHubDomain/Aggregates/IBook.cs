using DDD.DomainLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarPeaceAdminHubDomain.Aggregates
{
    public interface IBook: IEntity<Guid>
    {
        
        void FullUpdate(IBook o);
            
        public string Title { get; set; }

        public string ISBN { get; set; }
        
        DateTime PublishingDate { get; set; }
        
        //public Guid PublisherId { get; set; }
        
        decimal Cost { get; set; }    

        decimal RetailPrice { get; set; }     
        
        string CoverFileName { get; set; }
    
        
    }
}
