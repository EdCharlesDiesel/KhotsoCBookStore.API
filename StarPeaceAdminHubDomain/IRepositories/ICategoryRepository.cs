using DDD.DomainLayer;
using StarPeaceAdminHubDomain.Aggregates;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarPeaceAdminHubDomain.IRepositories
{
    // 11. An IRepository folder contains all repository specifications; namely,
    // IBookRepository, ICategoryRepository, and ICategoryEventRepository.
    // Here, ICategoryEventRepository is the repository associated with the ICategoryEvent.

    // Repositories always contain just a few methods since all business logic should be
    // represented as aggregate methods – in our case, just the methods to create a new
    // category, to retrieve an existing category, and to delete an existing category. The logic
    // to modify an existing category is included in the FullUpdate method of ICategory.
    public interface ICategoryRepository: IRepository<ICategory>
    {
        Task<ICategory> Get(int id);
        ICategory New();
        Task<ICategory> Delete(int id);
    }
}
