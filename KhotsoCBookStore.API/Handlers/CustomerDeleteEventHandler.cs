using DDD.ApplicationLayer;
using StarPeaceAdminHubDomain.Aggregates;
using StarPeaceAdminHubDomain.Events;
using StarPeaceAdminHubDomain.IRepositories;
using System.Threading.Tasks;

namespace KhotsoCBookStore.API.Handlers
{
    public class CustomerDeleteEventHandler :
        IEventHandler<CustomerDeleteEvent>
    {
        ICustomerEventRepository repo;
        public CustomerDeleteEventHandler(ICustomerEventRepository repo)
        {
            this.repo = repo;
        }
        public Task HandleAsync(CustomerDeleteEvent ev)
        {
            repo.New(CustomerEventType.Deleted, ev.CustomerId, ev.OldVersion);
            return Task.CompletedTask;
        }
    }
}
