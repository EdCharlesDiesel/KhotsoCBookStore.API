using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StarPeace.Admin.Contexts;


namespace StarPeace.Admin.Controllers
{
    [Route("api/[controller]")]
    public class ServiceAController : Controller
    {
         readonly StarPeaceAdminDbContext _dbContext;
        public ServiceAController(StarPeaceAdminDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
        }

        [HttpGet("{isbn}")]
        public StarPeace.Admin.Entities.Book Get(string isbn)
        {   
            var query = from b in _dbContext.Books
                        where b.ISBN == isbn && b.Source=="Book Store 1"
                        select b;
            return query.SingleOrDefault();            
        }
    }
}
