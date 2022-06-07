using DDD.ApplicationLayer;
using StarPeaceAdminHubDomain.DTOs;

namespace KhotsoCBookStore.API.Commands
{
    public class CreatePublisherCommand: ICommand
    {
        public CreatePublisherCommand(IPublisherFullEditDTO values)
        {
            Values = values;
        }
        public IPublisherFullEditDTO Values { get; private set; }
    }
}
