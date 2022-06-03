﻿using System;

namespace StarPeaceAdminHubDomain.DTOs
{
    public interface IMemberOrderFullEditDTO
    {
        int Id { get; set; }

        string FirstName { get; set; }

        string LastName { get; }

        decimal BookStartPrice { get; set; }

        DateTime? StartPublishingDate { get; }

        DateTime? EndPublishingDate { get; }

        int BookId { get; }
    }
}