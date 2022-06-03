using DDD.DomainLayer;
using StarPeaceAdminHubDomain.Aggregates;
using StarPeaceAdminHubDomain.IRepositories;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StarPeaceAdminHubDomain.Events;

namespace StarPeaceAdminHubDB.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private MainDbContext context;
        public CustomerRepository(MainDbContext context)
        {
            this.context = context;
        }
        public IUnitOfWork UnitOfWork => context;

        public async Task<ICustomer> Get(int id)
        {
            return await context.Customers.Where(m => m.Id == id)
                .FirstOrDefaultAsync();
        }
       
        public ICustomer New()
        {
            var model = new Customer() {EntityVersion=1 };
            context.Customers.Add(model);
            return model;
        }

        public async Task<ICustomer> Delete(int id)
        {
            var model = await Get(id);
            if (model == null) return null;
            context.Customers.Remove(model as Customer);
            model.AddDomainEvent(
                new CustomerDeleteEvent(
                    model.Id, (model as Customer).EntityVersion));
            return model;
        }
    }
}
