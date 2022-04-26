using DDD.ApplicationLayer;
using DDD.DomainLayer;
using StarPeaceAdminHub.Commands;
using StarPeaceAdminHubDomain.IRepositories;
using System.Threading.Tasks;

namespace StarPeaceAdminHub.Handlers
{
    public class DeleteCategoryCommandHandler : ICommandHandler<DeleteCategoryCommand>
    {
        ICategoryRepository repo;
        IEventMediator mediator;
        public DeleteCategoryCommandHandler(ICategoryRepository repo, IEventMediator mediator)
        {
            this.repo = repo;
            this.mediator = mediator;
        }
        public async Task HandleAsync(DeleteCategoryCommand command)
        {
            var deleted = await repo.Delete(command.CategoryId);
            if (deleted != null)
                await mediator.TriggerEvents(deleted.DomainEvents);
            await repo.UnitOfWork.SaveEntitiesAsync();
        }
    }
}
