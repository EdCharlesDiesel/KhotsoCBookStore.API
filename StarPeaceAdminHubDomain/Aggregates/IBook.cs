using DDD.DomainLayer;
using StarPeaceAdminHubDomain.DTOs;
using System;

namespace StarPeaceAdminHubDomain.Aggregates
{
    public interface IBook: IEntity<int>
    {    
        void FullUpdate(IBookFullEditDTO o);    
        
        string Title { get;  }

        string ISBN { get; }

        string Description {get;}
        
        DateTime PublishingDate { get;  }
        
        decimal Cost { get;  }    

        decimal RetailPrice { get;  }     
        
        string CoverFileName { get;  } 
               
    }
}
