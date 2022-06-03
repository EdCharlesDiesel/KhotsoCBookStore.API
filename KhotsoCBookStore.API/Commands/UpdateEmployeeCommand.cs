using DDD.ApplicationLayer;
using StarPeaceAdminHubDomain.DTOs;


namespace StarPeaceAdminHub.Commands
{
    public class UpdateEmployeeCommand: ICommand
    {
        public UpdateEmployeeCommand(IEmployeeFullEditDTO updates)
        {
            Updates = updates;
        }
        public IEmployeeFullEditDTO Updates { get; private set; }
    }
}
