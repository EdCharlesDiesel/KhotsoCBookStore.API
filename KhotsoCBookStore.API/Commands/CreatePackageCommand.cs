using DDD.ApplicationLayer;
using StarPeaceAdminHubDomain.DTOs;

namespace KhotsoCBookStore.API.Commands
{
    public class CreatePackageCommand: ICommand
    {
        public CreatePackageCommand(IPackageFullEditDTO values)
        {
            Values = values;
        }
        public IPackageFullEditDTO Values { get; private set; }
    }
}
