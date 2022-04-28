using DDD.DomainLayer;
using StarPeaceAdminHubDomain.Aggregates;
using System.Threading.Tasks;

namespace StarPeaceAdminHubDomain.IRepositories
{
    public interface IBookTitleRepository : IRepository<IBookTitle>
    {
        Task<IBookTitle> Get(int id);
        IBookTitle New();
        Task<IBookTitle> Delete(int id);
    }
}
