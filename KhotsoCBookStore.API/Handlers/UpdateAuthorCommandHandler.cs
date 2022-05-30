using DDD.ApplicationLayer;
using DDD.DomainLayer;
using KhotsoCBookStore.API.Commands;
using Microsoft.EntityFrameworkCore;
using StarPeaceAdminHubDomain.Aggregates;
using StarPeaceAdminHubDomain.IRepositories;
using System.Threading.Tasks;

namespace  KhotsoCBookStore.API.Handlers
{
    public class UpdateAuthorCommandHandler : ICommandHandler<UpdateAuthorCommand>
    {
        private readonly IAuthorRepository repo;
        private readonly IEventMediator mediator;
        public UpdateAuthorCommandHandler(IAuthorRepository repo, IEventMediator mediator)
        {
            this.repo = repo;
            this.mediator = mediator;
        }
        public async Task HandleAsync(UpdateAuthorCommand command)
        {
            bool done = false;
            IAuthor model;
            while (!done)
            {
                try
                {
                    model = await repo.Get(command.Updates.Id);
                    if (model == null) return;
                    model.FullUpdate(command.Updates);
                    await mediator.TriggerEvents(model.DomainEvents);
                    await repo.UnitOfWork.SaveEntitiesAsync();
                    done = true;
                }
                catch (DbUpdateConcurrencyException)
                {
                    //add here some logging
                }
            }
        }
    }
}
