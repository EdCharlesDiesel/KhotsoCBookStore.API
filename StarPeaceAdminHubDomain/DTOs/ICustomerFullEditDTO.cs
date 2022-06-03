using System;

namespace StarPeaceAdminHubDomain.DTOs
{
    public interface ICustomerFullEditDTO
    {
        int Id { get; set; }

        string FirstName { get; set; }

        string LastName { get;set; }

        DateTime DateOfBirth { get;set; }
        
        int IdNumber { get;set; }

        string SocialMediaFaceBook { get; set; }

    }
}
