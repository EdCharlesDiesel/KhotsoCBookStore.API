using DDD.ApplicationLayer;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeaceAdminHub.Queries
{
    public interface IBookListQuery: IQuery
    {
        Task<IEnumerable<SelectListItem>> AllBooks();
    }
}
