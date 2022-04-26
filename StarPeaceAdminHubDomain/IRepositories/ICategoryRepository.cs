using DDD.DomainLayer;
using StarPeaceAdminHubDomain.Aggregates;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarPeaceAdminHubDomain.IRepositories
{
    public interface ICategoryRepository: IRepository<ICategory>
    {
        Task<ICategory> Get(Guid id);
        ICategory New();
        Task<ICategory> Delete(Guid id);
    }
}
