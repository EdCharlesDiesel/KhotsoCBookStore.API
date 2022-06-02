using DDD.DomainLayer;
using StarPeaceAdminHubDomain.Aggregates;
using System.Threading.Tasks;

namespace StarPeaceAdminHubDomain.IRepositories
{
    public interface IPublisherRepository: IRepository<IPublisher>
    {
        Task<IPublisher> Get(int id);
        IPublisher New();
        Task<IPublisher> Delete(int id);
    }
}
