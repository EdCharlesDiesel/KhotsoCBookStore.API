using DDD.ApplicationLayer;
using StarPeaceAdminHub.Commands;
using StarPeaceAdminHubDomain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeaceAdminHub.Handlers
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
