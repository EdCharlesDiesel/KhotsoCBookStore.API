using DDD.ApplicationLayer;
using StarPeaceAdminHub.Commands;
using StarPeaceAdminHubDomain.IRepositories;
using System.Threading.Tasks;

namespace StarPeaceAdminHub.Handlers
{
    public class CreateCategoryCommandHandler : ICommandHandler<CreateCategoryCommand>
    {
        ICategoryRepository repo;
        public CreateCategoryCommandHandler(ICategoryRepository repo)
        {
            this.repo = repo;
        }
        public async Task  HandleAsync(CreateCategoryCommand command)
        {
            var model= repo.New();
            model.FullUpdate(command.Values);
            await repo.UnitOfWork.SaveEntitiesAsync();
        }
    }
}
