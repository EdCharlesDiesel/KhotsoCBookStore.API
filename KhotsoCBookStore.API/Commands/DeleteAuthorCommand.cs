using DDD.ApplicationLayer;

namespace KhotsoCBookStore.API.Commands
{
 public class DeleteAuthorCommand: ICommand
    {
        public DeleteAuthorCommand(int id)
        {
            AuthorId = id;
        }
        public int AuthorId { get; private set; }
    }
}