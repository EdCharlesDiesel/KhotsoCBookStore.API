using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeaceAdminHub.Models.Categorys
{
    public class CategorysListViewModel
    {
        public IEnumerable<CategoryInfosViewModel> Items { get; set; }
    }
}
