using DDD.DomainLayer;
using StarPeaceAdminHubDomain.DTOs;
using System;

namespace StarPeaceAdminHubDomain.Aggregates
{
    public interface IEmployee : IEntity<int>
    {
        void FullUpdate(IEmployeeFullEditDTO o);

        string FirstName { get; set; }

        string LastName { get;set;}

        int IdNumber { get; set; }

        DateTime StartOfEmployment { get;set;}
        
        DateTime? EndOfEmployement { get;set;  }
       
    }    
}
