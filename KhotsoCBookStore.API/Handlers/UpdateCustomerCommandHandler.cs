using DDD.ApplicationLayer;
using DDD.DomainLayer;
using KhotsoCBookStore.API.Commands;
using Microsoft.EntityFrameworkCore;
using StarPeaceAdminHubDomain.Aggregates;
using StarPeaceAdminHubDomain.IRepositories;
using System.Threading.Tasks;

namespace KhotsoCBookStore.API.Handlers
{
    public class UpdateCustomerCommandHandler : ICommandHandler<UpdateCustomerCommand>
    {
        ICustomerRepository repo;
        IEventMediator mediator;
        public UpdateCustomerCommandHandler(ICustomerRepository repo, IEventMediator mediator)
        {
            this.repo = repo;
            this.mediator = mediator;
        }
        public async Task HandleAsync(UpdateCustomerCommand command)
        {
            bool done = false;
            ICustomer model = null;
            while (!done)
            {
                try
                {
                    model = await repo.Get(command.Updates.CustomerId);
                    if (model == null) return;
                    model.FullUpdate(command.Updates);
                    await mediator.TriggerEvents(model.DomainEvents);
                    await repo.UnitOfWork.SaveEntitiesAsync();
                    done = true;
                }
                catch (DbUpdateConcurrencyException)
                {

                }
            }
        }
    }
}
