using DDD.DomainLayer;
using StarPeaceAdminHubDomain.Aggregates;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StarPeaceAdminHubDomain.IRepositories
{
    public interface IMemberOrderEventRepository:IRepository<IMemberOrderEvent>
    {
        Task<IEnumerable<IMemberOrderEvent>> GetFirstN(int n);
        IMemberOrderEvent New(MemberOrderEventType type, int id, long oldVersion, long? newVersion= null, decimal bookStartprice = 0);
    }
}
