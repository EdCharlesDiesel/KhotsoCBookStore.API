using DDD.DomainLayer;
using StarPeaceAdminHubDomain.Aggregates;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StarPeaceAdminHubDomain.IRepositories
{
    public interface IEmployeeEventRepository:IRepository<IEmployeeEvent>
    {
        Task<IEnumerable<IEmployeeEvent>> GetFirstN(int n);
        IEmployeeEvent New(EmployeeEventType type, int id, long oldVersion, long? newVersion= null, decimal bookStartprice = 0);
    }
}
