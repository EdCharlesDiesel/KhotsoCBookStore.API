using StarPeaceAdminHubDomain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeaceAdminHub.Models.Categorys
{
    public class CategoryInfosViewModel
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }

        public Guid BookId { get; set; }
        public override string ToString()
        {
            return string.Format("{0}. bookId, CategoryName: {3}",
                BookId, CategoryName);
        }
    }
}
