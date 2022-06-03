using DDD.ApplicationLayer;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KhotsoCBookStore.API.Queries
{
    public interface IBookListQuery: IQuery
    {
        Task<IEnumerable<SelectListItem>> AllBooks();       

    }
}
