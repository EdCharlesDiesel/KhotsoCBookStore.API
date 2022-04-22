using DDD.DomainLayer;
using StarPeaceAdminHubDomain.Aggregates;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarPeaceAdminHubDomain.IRepositories
{
    public interface IPackageRepository: IRepository<IPackage>
    {
        Task<IPackage> Get(int id);
        IPackage New();
        Task<IPackage> Delete(int id);
    }
}
