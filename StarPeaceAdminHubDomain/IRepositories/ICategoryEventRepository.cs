using DDD.DomainLayer;
using StarPeaceAdminHubDomain.Aggregates;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarPeaceAdminHubDomain.IRepositories
{
    public interface ICategoryEventRepository:IRepository<ICategoryEvent>
    {
        Task<IEnumerable<ICategoryEvent>> GetFirstN(Guid n);
        //ICategoryEvent New(CategoryEventType type, Guid id, long oldVersion, long? newVersion= null, decimal price = 0);
        ICategoryEvent New(CategoryEventType type, Guid id, long oldVersion, long? newVersion= null, string categoryName = null);
    
    }
}
