using DDD.ApplicationLayer;
using StarPeaceAdminHubDomain.DTOs;


namespace StarPeaceAdminHub.Commands
{
    public class UpdateCategoryCommand: ICommand
    {
        public UpdateCategoryCommand(ICategoryFullEditDTO updates)
        {
            Updates = updates;
        }
        public ICategoryFullEditDTO Updates { get; private set; }
    }
}
