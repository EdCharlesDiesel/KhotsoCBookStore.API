using DDD.DomainLayer;
using StarPeaceAdminHubDomain.Aggregates;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarPeaceAdminHubDomain.IRepositories
{
    public interface IBookTitleEventRepository : IRepository<IBookTitleEvent>
    {
        Task<IEnumerable<IBookTitleEvent>> GetFirstN(int n);
        
        IBookTitleEvent New(BookTitleEventType type, int id, long oldVersion, long? newVersion = null);
    
    }
}
