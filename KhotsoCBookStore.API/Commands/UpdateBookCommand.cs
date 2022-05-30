using DDD.ApplicationLayer;
using StarPeaceAdminHubDomain.DTOs;


namespace KhotsoCBookStore.API.Commands
{
    public class UpdateBookCommand: ICommand
    {
        public UpdateBookCommand(IBookFullEditDTO updates)
        {
            Updates = updates;
        }
        public IBookFullEditDTO Updates { get; private set; }
    }
}
