using DDD.ApplicationLayer;
using StarPeaceAdminHub.Models.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeaceAdminHub.Queries
{
    public interface IBooksListQuery: IQuery
    {
        Task<IEnumerable<BookInfosViewModel>> GetAllBooks();
        
    }
}
