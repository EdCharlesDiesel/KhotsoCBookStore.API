using DDD.ApplicationLayer;
using StarPeaceAdminHubDomain.DTOs;


namespace StarPeaceAdminHub.Commands
{
    // The Commands folder contains all commands. As an example, let's have a look at the
    // command used to modify packages:
    // Its constructor must be invoked with an implementation of the ICategoryFullEditDTO
    // DTO interface, which, in our case, is the edit ViewModel we described previously.
    // Command handlers are placed in the Handlers folder. It is worth analyzing the
    // command that updates packages:
    public class UpdateCategoryCommand: ICommand
    {
        public UpdateCategoryCommand(ICategoryFullEditDTO updates)
        {
            Updates = updates;
        }
        public ICategoryFullEditDTO Updates { get; private set; }
    }
}
