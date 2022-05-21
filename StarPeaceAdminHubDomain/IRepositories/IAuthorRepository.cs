using DDD.DomainLayer;
using StarPeaceAdminHubDomain.Aggregates;
using System.Threading.Tasks;

namespace StarPeaceAdminHubDomain.IRepositories
{
    public interface IAuthorRepository: IRepository<IAuthor>
    {
        Task<IAuthor> Get(int id);
        IAuthor New();
        Task<IAuthor> Delete(int id);
    }
}
