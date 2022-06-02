using DDD.DomainLayer;
using StarPeaceAdminHubDomain.Aggregates;
using System.Threading.Tasks;

namespace StarPeaceAdminHubDomain.IRepositories
{
    public interface ICustomerRepository: IRepository<ICustomer>
    {
        Task<ICustomer> Get(int id);
        ICustomer New();
        Task<ICustomer> Delete(int id);
    }
}
