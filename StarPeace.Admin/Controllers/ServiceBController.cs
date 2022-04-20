using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StarPeace.Admin.Contexts;
using Microsoft.AspNetCore.Http;

namespace  StarPeace.Admin.Controllers
{
    [Route("api/[controller]")]
    public class ServiceBController : Controller
    {
        readonly StarPeaceAdminDbContext _dbContext;
        public ServiceBController(StarPeaceAdminDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
        }

        [HttpGet("{isbn}")]
        public StarPeace.Admin.Entities.Book Get(string isbn)
        {

                var query = from b in _dbContext.Books
                            where b.ISBN == isbn && b.Source == "Book Store 2"
                            select b;
                return query.SingleOrDefault();
        }
    }
}