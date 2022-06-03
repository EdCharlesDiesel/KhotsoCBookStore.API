using DDD.ApplicationLayer;
using StarPeaceAdminHubDomain.IRepositories;
using System.Threading.Tasks;
using KhotsoCBookStore.API.Commands;

namespace KhotsoCBookStore.API.Handlers
{
    public class CreateCustomerCommandHandler : ICommandHandler<CreateCustomerCommand>
    {
        ICustomerRepository repo;
        public CreateCustomerCommandHandler(ICustomerRepository repo)
        {
            this.repo = repo;
        }
        public async Task  HandleAsync(CreateCustomerCommand command)
        {
            var model= repo.New();
            model.FullUpdate(command.Values);
            await repo.UnitOfWork.SaveEntitiesAsync();
        }
    }
}
