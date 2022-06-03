using DDD.ApplicationLayer;
using StarPeaceAdminHubDomain.IRepositories;
using System.Threading.Tasks;
using KhotsoCBookStore.API.Commands;

namespace KhotsoCBookStore.API.Handlers
{
    public class CreateBookCommandHandler : ICommandHandler<CreateBookCommand>
    {
        IBookRepository repo;
        public CreateBookCommandHandler(IBookRepository repo)
        {
            this.repo = repo;
        }
        public async Task  HandleAsync(CreateBookCommand command)
        {
            var model= repo.New();
            model.FullUpdate(command.Values);
            await repo.UnitOfWork.SaveEntitiesAsync();
        }
    }
}
