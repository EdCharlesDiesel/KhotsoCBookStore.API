using DDD.ApplicationLayer;
using StarPeaceAdminHubDomain.IRepositories;
using System.Threading.Tasks;
using KhotsoCBookStore.API.Commands;

namespace KhotsoCBookStore.API.Handlers
{
    public class CreatePackageCommandHandler : ICommandHandler<CreatePackageCommand>
    {
        IPackageRepository repo;
        public CreatePackageCommandHandler(IPackageRepository repo)
        {
            this.repo = repo;
        }
        public async Task  HandleAsync(CreatePackageCommand command)
        {
            var model= repo.New();
            model.FullUpdate(command.Values);
            await repo.UnitOfWork.SaveEntitiesAsync();
        }
    }
}
