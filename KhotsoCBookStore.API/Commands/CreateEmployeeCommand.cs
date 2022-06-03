using DDD.ApplicationLayer;
using StarPeaceAdminHubDomain.DTOs;

namespace KhotsoCBookStore.API.Commands
{
    public class CreateEmployeeCommand: ICommand
    {
        public CreateEmployeeCommand(IEmployeeFullEditDTO values)
        {
            Values = values;
        }
        public IEmployeeFullEditDTO Values { get; private set; }
    }
}
