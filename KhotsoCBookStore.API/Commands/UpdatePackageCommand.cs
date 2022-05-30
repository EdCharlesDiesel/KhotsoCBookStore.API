using DDD.ApplicationLayer;
using StarPeaceAdminHubDomain.DTOs;


namespace StarPeaceAdminHub.Commands
{
    public class UpdatePackageCommand: ICommand
    {
        public UpdatePackageCommand(IPackageFullEditDTO updates)
        {
            Updates = updates;
        }
        public IPackageFullEditDTO Updates { get; private set; }
    }
}
