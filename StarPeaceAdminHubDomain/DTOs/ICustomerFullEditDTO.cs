using System;

namespace StarPeaceAdminHubDomain.DTOs
{
    public interface ICustomerFullEditDTO
    {
        int Id { get; set; }

        string FirstName { get; set; }

        string LastName { get; }

        DateTime DateOfBirth { get; }

        DateTime? EndPublishingDate { get; }
        
        int IdNumber { get; }

        string SocialMediaFaceBook { get; set; }

       // int BookId { get; }
    }
}
