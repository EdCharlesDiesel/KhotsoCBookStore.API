using DDD.ApplicationLayer;
using StarPeaceAdminHubDomain.DTOs;


namespace StarPeaceAdminHub.Commands
{
    public class UpdateOrderCommand: ICommand
    {
        public UpdateOrderCommand(IOrderFullEditDTO updates)
        {
            Updates = updates;
        }
        public IOrderFullEditDTO Updates { get; private set; }
    }
}
