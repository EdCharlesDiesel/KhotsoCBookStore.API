using DDD.DomainLayer;
using StarPeaceAdminHubDomain.Aggregates;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StarPeaceAdminHubDomain.IRepositories
{
    public interface ICustomerEventRepository:IRepository<ICustomerEvent>
    {
        Task<IEnumerable<ICustomerEvent>> GetFirstN(int n);
        ICustomerEvent New(CustomerEventType type, int id, long oldVersion, long? newVersion= null, decimal bookStartprice = 0);
    }
}
