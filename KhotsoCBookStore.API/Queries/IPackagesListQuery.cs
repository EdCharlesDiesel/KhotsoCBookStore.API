using DDD.ApplicationLayer;
using KhotsoCBookStore.API.Models.Packages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KhotsoCBookStore.API.Queries
{
    public interface IPackagesListQuery: IQuery
    {
        Task<IEnumerable<PackageInfosViewModel>> GetAllPackages();
        
    }
}
