﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StarPeaceAdminHubDomain.DTOs
{
    public interface IBookFullEditDTO
    {
        Guid Id { get; set; }
        string Name { get; set; }

        string Description { get; }
        decimal Price { get; set; }
        int DurationInDays { get; }
        DateTime? StartValidityDate { get; }
        DateTime? EndValidityDate { get; }
        int DestinationId { get; }
    }
}
