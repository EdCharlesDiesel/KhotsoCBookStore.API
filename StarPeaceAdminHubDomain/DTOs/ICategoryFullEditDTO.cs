using System;
using System.Collections.Generic;
using System.Text;

namespace StarPeaceAdminHubDomain.DTOs
{
    /* 10.  Here, we place all interfaces used to pass
        updates to the aggregates. Such interfaces are implemented by the application
        layer ViewModels used to define such updates. In our case, it contains
        IPackageFullEditDTO, which we can use to update existing packages. If you would
        like to add the logic to manage destinations, you must define an analogous interface
        for the IDestination aggregate.     
    */
    public interface ICategoryFullEditDTO
    {
        int Id { get; set; }

        string CategoryName { get; set; }
        
        int BookId { get; }
    }
}
