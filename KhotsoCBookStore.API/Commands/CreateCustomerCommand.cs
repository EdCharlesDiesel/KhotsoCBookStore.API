using DDD.ApplicationLayer;
using StarPeaceAdminHubDomain.DTOs;

namespace KhotsoCBookStore.API.Commands
{
    public class CreateCustomerCommand: ICommand
    {
        public CreateCustomerCommand(ICustomerFullEditDTO values)
        {
            Values = values;
        }
        public ICustomerFullEditDTO Values { get; private set; }
    }
}
