using DDD.ApplicationLayer;
using DDD.DomainLayer;
using StarPeaceAdminHub.Commands;
using StarPeaceAdminHubDomain.IRepositories;
using System.Threading.Tasks;

namespace StarPeaceAdminHub.Handlers
{
    public class DeleteBookCommandHandler : ICommandHandler<DeleteBookCommand>
    {
        IBookRepository repo;
        IEventMediator mediator;
        public DeleteBookCommandHandler(IBookRepository repo, IEventMediator mediator)
        {
            this.repo = repo;
            this.mediator = mediator;
        }
        public async Task HandleAsync(DeleteBookCommand command)
        {
            var deleted = await repo.Delete(command.BookId);
            if (deleted != null)
                await mediator.TriggerEvents(deleted.DomainEvents);
            await repo.UnitOfWork.SaveEntitiesAsync();
        }
    }
}
