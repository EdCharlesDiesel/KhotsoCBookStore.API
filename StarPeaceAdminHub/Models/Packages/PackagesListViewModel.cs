using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeaceAdminHub.Models.Packages
{
    public class PackagesListViewModel
    {
        public IEnumerable<PackageInfosViewModel> Items { get; set; }
    }
}
