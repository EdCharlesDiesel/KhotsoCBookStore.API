using DDD.DomainLayer;
using StarPeaceAdminHubDomain.Aggregates;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StarPeaceAdminHubDomain.IRepositories
{
    public interface IPublisherEventRepository:IRepository<IPublisherEvent>
    {
        Task<IEnumerable<IPublisherEvent>> GetFirstN(int n);
        IPublisherEvent New(PublisherEventType type, int id, long oldVersion, long? newVersion= null);
    }
}
