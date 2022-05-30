using DDD.ApplicationLayer;

namespace KhotsoCBookStore.API.Commands
{
    public class DeletePackageCommand: ICommand
    {
        public DeletePackageCommand(int id)
        {
            PackageId = id;
        }
        public int PackageId { get; private set; }
    }
}
