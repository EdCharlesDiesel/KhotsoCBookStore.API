using DDD.DomainLayer;
using StarPeaceAdminHubDomain.Aggregates;
using System.Threading.Tasks;

namespace StarPeaceAdminHubDomain.IRepositories
{
    public interface IMemberOrderRepository: IRepository<IMemberOrder>
    {
        Task<IMemberOrder> Get(int id);
        IMemberOrder New();
        Task<IMemberOrder> Delete(int id);
    }
}
