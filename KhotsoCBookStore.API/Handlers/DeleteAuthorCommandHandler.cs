using DDD.ApplicationLayer;
using DDD.DomainLayer;
using StarPeaceAdminHubDomain.IRepositories;
using System.Threading.Tasks;
using KhotsoCBookStore.API.Commands;

namespace KhotsoCBookStore.API.Handlers
{
    public class DeleteAuthorCommandHandler : ICommandHandler<DeleteAuthorCommand>
    {
        IAuthorRepository repo;
        IEventMediator mediator;
        public DeleteAuthorCommandHandler(IAuthorRepository repo, IEventMediator mediator)
        {
            this.repo = repo;
            this.mediator = mediator;
        }
        public async Task HandleAsync(DeleteAuthorCommand command)
        {
            var deleted = await repo.Delete(command.AuthorId);
            if (deleted != null)
                await mediator.TriggerEvents(deleted.DomainEvents);
            await repo.UnitOfWork.SaveEntitiesAsync();
        }
    }
}
