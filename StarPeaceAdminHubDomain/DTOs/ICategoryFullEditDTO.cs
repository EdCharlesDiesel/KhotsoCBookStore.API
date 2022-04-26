using System;
using System.Collections.Generic;
using System.Text;

namespace StarPeaceAdminHubDomain.DTOs
{
    public interface ICategoryFullEditDTO
    {
        int Id { get; set; }
        string CategoryName { get; set; }
        int BookId { get; }
    }
}
