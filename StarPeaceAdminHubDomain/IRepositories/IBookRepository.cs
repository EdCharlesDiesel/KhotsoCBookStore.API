using DDD.DomainLayer;
using StarPeaceAdminHubDomain.Aggregates;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarPeaceAdminHubDomain.IRepositories
{

    // 6. During its execution, the handler interacts with various
    // repository interface methods and with the aggregates they return.
    public interface IBookRepository:IRepository<IBook>
    {
        Task<IBook> Get(int id);
        IBook New();
    }
}
