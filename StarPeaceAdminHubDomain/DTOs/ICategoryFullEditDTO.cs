using System;
using System.Collections.Generic;
using System.Text;

namespace StarPeaceAdminHubDomain.DTOs
{
    public interface ICategoryFullEditDTO
    {
        Guid CategoryId { get; set; }
        string CategoryName { get; set; }

        // string Description { get; }
        // decimal Price { get; set; }
        // int DurationInDays { get; }
        // DateTime? StartValidityDate { get; }
        // DateTime? EndValidityDate { get; }
        Guid BookId { get; }
    }
}
