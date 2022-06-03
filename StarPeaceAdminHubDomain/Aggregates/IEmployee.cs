using DDD.DomainLayer;
using StarPeaceAdminHubDomain.DTOs;
using System;

namespace StarPeaceAdminHubDomain.Aggregates
{
    public interface IEmployee : IEntity<int>
    {
        void FullUpdate(IEmployeeFullEditDTO o);

        string FirstName { get; set; }

        string LastName { get;}

        string IdNumber { get; set; }

        decimal BookStartPrice { get; set; }

        DateTime BeginingOfEmployement { get;}
        
        DateTime? EndOfEmployement { get;  }
       
    }    
}
