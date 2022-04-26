using DDD.ApplicationLayer;
using DDD.DomainLayer;
using Microsoft.EntityFrameworkCore;
using StarPeaceAdminHub.Commands;
using StarPeaceAdminHubDomain.Aggregates;
using StarPeaceAdminHubDomain.IRepositories;
using System.Threading.Tasks;

namespace StarPeaceAdminHub.Handlers
{
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
                    model = await repo.Get(command.Updates.CategoryId);
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
