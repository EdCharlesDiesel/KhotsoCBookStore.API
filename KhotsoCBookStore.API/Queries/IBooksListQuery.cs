using DDD.ApplicationLayer;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KhotsoCBookStore.API.Queries
{
    public interface IBooksListQuery: IQuery
    {
        Task<IEnumerable<SelectListItem>> GetAllBooks();       

    }
}
