using DDD.DomainLayer;
using StarPeaceAdminHubDomain.Aggregates;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarPeaceAdminHubDomain.IRepositories
{
    public interface IPackageEventRepository:IRepository<IPackageEvent>
    {
        Task<IEnumerable<IPackageEvent>> GetFirstN(int n);
        IPackageEvent New(PackageEventType type, int id, long oldVersion, long? newVersion= null, decimal price = 0);
    }
}
