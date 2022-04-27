using DDD.ApplicationLayer;
using DDD.DomainLayer;
using Microsoft.EntityFrameworkCore;
using StarPeaceAdminHub.Commands;
using StarPeaceAdminHubDomain.Aggregates;
using StarPeaceAdminHubDomain.IRepositories;
using System.Threading.Tasks;

namespace StarPeaceAdminHub.Handlers
{
    // 8. Handlers
    // use the IUnitOfWork interface contained in each IRepository, as well as
    // the concurrency exceptions returned by the data layer, to organize their
    // operations as transactions. It is worth pointing out that each aggregate has
    // its own IRepository, and that the whole logic for updating each aggregate is
    // defined in the aggregate itself, not in its associated IRepository, to keep the
    // code more modular.
    public class UpdateCategoryCommandHandler : ICommandHandler<UpdateCategoryCommand>
    {
        ICategoryRepository repo;
        IEventMediator mediator;
        public UpdateCategoryCommandHandler(ICategoryRepository repo, IEventMediator mediator)
        {
            this.repo = repo;
            this.mediator = mediator;
        }
        public async Task HandleAsync(UpdateCategoryCommand command)
        {
            bool done = false;
            ICategory model = null;
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

                }
            }
        }
    }
}
