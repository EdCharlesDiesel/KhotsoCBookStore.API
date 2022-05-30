using DDD.ApplicationLayer;
using StarPeaceAdminHub.Models.Packages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeaceAdminHub.Queries
{
    public interface IPackagesListQuery: IQuery
    {
        Task<IEnumerable<PackageInfosViewModel>> GetAllPackages();
        
    }
}
