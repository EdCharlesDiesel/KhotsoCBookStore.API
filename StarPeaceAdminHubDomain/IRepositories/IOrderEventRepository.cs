using DDD.DomainLayer;
using StarPeaceAdminHubDomain.Aggregates;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StarPeaceAdminHubDomain.IRepositories
{
    public interface IOrderEventRepository:IRepository<IOrderEvent>
    {
        Task<IEnumerable<IOrderEvent>> GetFirstN(int n);
        IOrderEvent New(OrderEventType type, int id, long oldVersion, long? newVersion= null);
    }
}
