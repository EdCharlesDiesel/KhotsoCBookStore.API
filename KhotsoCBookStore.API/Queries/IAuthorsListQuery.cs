using DDD.ApplicationLayer;
using KhotsoCBookStore.API.Models.Authors;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KhotsoCBookStore.API.Queries
{
    public interface IAuthorsListQuery: IQuery
    {
        Task<IEnumerable<AuthorInfosViewModel>> GetAllAuthors();
       // Task<AuthorInfosViewModel> GetAuthorById(int authorId);
        
    }
}
