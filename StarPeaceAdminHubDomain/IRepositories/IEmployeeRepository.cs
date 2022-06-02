using DDD.DomainLayer;
using StarPeaceAdminHubDomain.Aggregates;
using System.Threading.Tasks;

namespace StarPeaceAdminHubDomain.IRepositories
{
    public interface IEmployeeRepository: IRepository<IEmployee>
    {
        Task<IEmployee> Get(int id);
        IEmployee New();
        Task<IEmployee> Delete(int id);
    }
}
