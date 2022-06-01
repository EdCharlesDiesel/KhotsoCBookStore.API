using DDD.ApplicationLayer;
using KhotsoCBookStore.API.Models.Authors;
using System.Threading.Tasks;

namespace KhotsoCBookStore.API.Queries
{
    public interface IAuthorQuery: IQuery
    {
        Task<AuthorInfosViewModel> GetAuthorById(int authorId);        
    }
}
