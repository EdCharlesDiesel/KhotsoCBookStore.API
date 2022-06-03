using DDD.ApplicationLayer;
using StarPeaceAdminHubDomain.DTOs;

namespace KhotsoCBookStore.API.Commands
{
    public class UpdateCustomerCommand: ICommand
    {
        public UpdateCustomerCommand(ICustomerFullEditDTO updates)
        {
            Updates = updates;
        }
        public ICustomerFullEditDTO Updates { get; private set; }
    }
}