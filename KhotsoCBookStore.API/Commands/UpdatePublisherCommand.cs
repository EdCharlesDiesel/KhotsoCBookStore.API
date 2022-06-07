using DDD.ApplicationLayer;
using StarPeaceAdminHubDomain.DTOs;


namespace StarPeaceAdminHub.Commands
{
    public class UpdatePublisherCommand: ICommand
    {
        public UpdatePublisherCommand(IPublisherFullEditDTO updates)
        {
            Updates = updates;
        }
        public IPublisherFullEditDTO Updates { get; private set; }
    }
}
