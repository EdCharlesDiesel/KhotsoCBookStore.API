using DDD.ApplicationLayer;

namespace KhotsoCBookStore.API.Commands
{
    public class DeleteOrderCommand: ICommand
    {
        public DeleteOrderCommand(int id)
        {
            OrderId = id;
        }
        public int OrderId { get; private set; }
    }
}
