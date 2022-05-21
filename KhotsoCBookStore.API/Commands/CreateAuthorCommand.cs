using DDD.ApplicationLayer;
using StarPeaceAdminHubDomain.DTOs;

namespace KhotsoCBookStore.API.Commands
{
    public class CreateAuthorCommand: ICommand
    {
        public CreateAuthorCommand(IAuthorFullEditDTO values)
        {
            Values = values;
        }
        public IAuthorFullEditDTO Values { get; private set; }
    }
}
