using DDD.ApplicationLayer;

namespace KhotsoCBookStore.API.Commands
{
 public class DeleteBookCommand: ICommand
    {
        public DeleteBookCommand(int id)
        {
            BookId = id;
        }
        public int BookId { get; private set; }
    }
}