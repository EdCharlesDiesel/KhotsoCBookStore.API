using DDD.ApplicationLayer;
using StarPeaceAdminHubDomain.Aggregates;
using StarPeaceAdminHubDomain.Events;
using StarPeaceAdminHubDomain.IRepositories;
using System.Threading.Tasks;

namespace KhotsoCBookStore.API.Handlers
{
    public class BookDeleteEventHandler : IEventHandler<BookDeleteEvent>
    {
        IBookEventRepository repo;
        public BookDeleteEventHandler(IBookEventRepository repo)
        {
            this.repo = repo;
        }
        public Task HandleAsync(BookDeleteEvent ev)
        {
            repo.New(BookEventType.Deleted, ev.BookId, ev.OldVersion);
            return Task.CompletedTask;
        }
    }
}
