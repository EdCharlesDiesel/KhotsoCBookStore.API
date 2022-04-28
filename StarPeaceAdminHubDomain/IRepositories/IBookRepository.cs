using DDD.DomainLayer;
using StarPeaceAdminHubDomain.Aggregates;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarPeaceAdminHubDomain.IRepositories
{
    public interface IBookRepository : IRepository<IBookTitle>
    {
        Task<IBook> Get(int id);
        IBook New();
        Task<IBook> Delete(int id);
    }
}
