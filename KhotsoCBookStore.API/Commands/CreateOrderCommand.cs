using DDD.ApplicationLayer;
using StarPeaceAdminHubDomain.DTOs;

namespace KhotsoCBookStore.API.Commands
{
    public class CreateOrderCommand: ICommand
    {
        public CreateOrderCommand(IOrderFullEditDTO values)
        {
            Values = values;
        }
        public IOrderFullEditDTO Values { get; private set; }
    }
}
