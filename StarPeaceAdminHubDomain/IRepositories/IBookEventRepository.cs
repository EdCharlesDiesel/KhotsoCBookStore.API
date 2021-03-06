using DDD.DomainLayer;
using StarPeaceAdminHubDomain.Aggregates;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarPeaceAdminHubDomain.IRepositories
{
    public interface IBookEventRepository:IRepository<IBookEvent>
    {
        Task<IEnumerable<IBookEvent>> GetFirstN(int n);
        IBookEvent New(BookEventType type, int id, long oldVersion, long? newVersion= null, decimal price = 0);
    }
}
