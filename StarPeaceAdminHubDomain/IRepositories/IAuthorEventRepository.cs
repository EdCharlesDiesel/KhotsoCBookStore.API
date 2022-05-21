using DDD.DomainLayer;
using StarPeaceAdminHubDomain.Aggregates;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthorsManagementDomain.IRepositories
{
    public interface IAuthorEventRepository:IRepository<IAuthorEvent>
    {
        Task<IEnumerable<IAuthorEvent>> GetFirstN(int n);
        IAuthorEvent New(AuthorEventType type, int id, long oldVersion, long? newVersion= null, decimal bookStartprice = 0);
    }
}
