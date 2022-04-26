using DDD.ApplicationLayer;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeaceAdminHub.Queries
{
    public interface ICategoryListQuery: IQuery
    {
        Task<IEnumerable<SelectListItem>> AllCategorys();
    }
}
