using DDD.ApplicationLayer;
using KhotsoCBookStore.API.Commands;
using StarPeaceAdminHubDomain.IRepositories;
using System.Threading.Tasks;

namespace KhotsoCBookStore.API.Handlers
{
    public class CreateAuthorCommandHandler : ICommandHandler<CreateAuthorCommand>
    {
        IAuthorRepository repo;
        public CreateAuthorCommandHandler(IAuthorRepository repo)
        {
            this.repo = repo;
        }
        public async Task  HandleAsync(CreateAuthorCommand command)
        {
            var model= repo.New();
            model.FullUpdate(command.Values);
            await repo.UnitOfWork.SaveEntitiesAsync();
        }
    }
}
