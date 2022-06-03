using DDD.ApplicationLayer;
using KhotsoCBookStore.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KhotsoCBookStore.API.Queries
{
    public interface IBooksListQuery: IQuery
    {      
        Task<IEnumerable<BookInfosViewModel>> GetAllBooks();
        Task<BookInfosViewModel> GetBookById(int authorId);
    }
}
