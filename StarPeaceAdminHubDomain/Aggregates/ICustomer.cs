using DDD.DomainLayer;
using StarPeaceAdminHubDomain.DTOs;
using System;

namespace StarPeaceAdminHubDomain.Aggregates
{
    public interface ICustomer : IEntity<int>
    {
        void FullUpdate(ICustomerFullEditDTO o);
        string FirstName { get; set; }
        string LastName { get; set; }
        DateTime DateOfBirth { get; set; }
        int IdNumber { get; set; }
        string SocialMediaFaceBook { get; set; }
    }
}
