using DDD.ApplicationLayer;
using StarPeaceAdminHubDomain.DTOs;

namespace KhotsoCBookStore.API.Commands
{
    public class CreateBookCommand: ICommand
    {
        public CreateBookCommand(IBookFullEditDTO values)
        {
            Values = values;
        }
        public IBookFullEditDTO Values { get; private set; }
    }
}
