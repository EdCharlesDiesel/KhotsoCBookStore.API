using DDD.ApplicationLayer;
using StarPeaceAdminHubDomain.DTOs;

namespace KhotsoCBookStore.API.Commands
{
    public class UpdateAuthorCommand: ICommand
    {
        public UpdateAuthorCommand(IAuthorFullEditDTO updates)
        {
            Updates = updates;
        }
        public IAuthorFullEditDTO Updates { get; private set; }
    }
}