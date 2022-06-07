using DDD.DomainLayer;
using StarPeaceAdminHubDomain.Aggregates;
using System.Threading.Tasks;

namespace StarPeaceAdminHubDomain.IRepositories
{
    public interface IOrderRepository: IRepository<IOrder>
    {
        Task<IOrder> Get(int id);
        IOrder New();
        Task<IOrder> Delete(int id);
    }
}
