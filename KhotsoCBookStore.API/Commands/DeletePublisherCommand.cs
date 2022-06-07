using DDD.ApplicationLayer;

namespace KhotsoCBookStore.API.Commands
{
    public class DeletePublisherCommand: ICommand
    {
        public DeletePublisherCommand(int id)
        {
            PublisherId = id;
        }
        public int PublisherId { get; private set; }
    }
}
