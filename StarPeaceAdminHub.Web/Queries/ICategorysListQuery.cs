using DDD.ApplicationLayer;
using StarPeaceAdminHub.Models.Categorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeaceAdminHub.Queries
{
    public interface ICategorysListQuery: IQuery
    {
        Task<IEnumerable<CategoryInfosViewModel>> GetAllCategorys();
        
    }
}
