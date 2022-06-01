namespace KhotsoCBookStore.API.Controllers
{
    public class DeleteAuthorCommand
    {
        private int authorId;

        public DeleteAuthorCommand(int authorId)
        {
            this.authorId = authorId;
        }
    }
}