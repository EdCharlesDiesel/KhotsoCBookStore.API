using DDD.ApplicationLayer;
using DDD.DomainLayer;
using KhotsoCBookStore.API.Commands;
using Microsoft.EntityFrameworkCore;
using StarPeaceAdminHubDomain.Aggregates;
using StarPeaceAdminHubDomain.IRepositories;
using System.Threading.Tasks;

namespace KhotsoCBookStore.API.Handlers
{
    public class UpdateBookCommandHandler : ICommandHandler<UpdateBookCommand>
    {
        IBookRepository repo;
        IEventMediator mediator;
        public UpdateBookCommandHandler(IBookRepository repo, IEventMediator mediator)
        {
            this.repo = repo;
            this.mediator = mediator;
        }
        public async Task HandleAsync(UpdateBookCommand command)
        {
            bool done = false;
            IBook model = null;
            while (!done)
            {
                try
                {
                    model = await repo.Get(command.Updates.BookId);
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
