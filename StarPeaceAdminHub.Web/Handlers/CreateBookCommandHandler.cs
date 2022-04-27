using DDD.ApplicationLayer;
using StarPeaceAdminHub.Commands;
using StarPeaceAdminHubDomain.IRepositories;
using System.Threading.Tasks;
using System;

namespace StarPeaceAdminHub.Handlers
{
    // 6. During its execution, the handler interacts with various
    // repository interface methods and with the aggregates they return.

    //7. DI engine automatically injects all parameters declared in its constructor. In
    //particular, it injects all IRepository implementations needed to perform all
    //command handler transactions
    public class CreateBookCommandHandler : ICommandHandler<CreateBookCommand>
    {
        IBookRepository repo;
        public CreateBookCommandHandler(IBookRepository repo)
        {
            this.repo = repo;
        }
        public async Task  HandleAsync(CreateBookCommand command)
        {
            // var model= repo.New();
            // model.FullUpdate(command.Values);
            // await repo.UnitOfWork.SaveEntitiesAsync();
            throw new NotImplementedException();
        }
    }
}
