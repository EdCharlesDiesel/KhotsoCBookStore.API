using DDD.ApplicationLayer;
using StarPeaceAdminHubDomain.Aggregates;
using StarPeaceAdminHubDomain.Events;
using StarPeaceAdminHubDomain.IRepositories;
using System.Threading.Tasks;

namespace StarPeaceAdminHub.Handlers
{
    public class BookPriceChangedEventHandler :
        IEventHandler<BookPriceChangedEvent>
    {
        IBookEventRepository repo;
        public BookPriceChangedEventHandler(IBookEventRepository repo)
        {
            this.repo = repo;
        }
        public Task HandleAsync(BookPriceChangedEvent ev)
        {
            repo.New(BookEventType.CostChanged, ev.BookId, ev.OldVersion, ev.NewVersion, ev.NewPrice);
            return Task.CompletedTask;
        }
    }
}
