using DDD.ApplicationLayer;
using StarPeaceAdminHubDomain.IRepositories;
using System.Threading.Tasks;
using KhotsoCBookStore.API.Commands;

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
