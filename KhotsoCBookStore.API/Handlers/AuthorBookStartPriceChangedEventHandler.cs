using DDD.ApplicationLayer;
using StarPeaceAdminHubDomain.Aggregates;
using StarPeaceAdminHubDomain.Events;
using StarPeaceAdminHubDomain.IRepositories;
using System.Threading.Tasks;

namespace KhotsoCBookStore.API.Handlers
{
    public class AuthorBookStartPriceChangedEventHandler :
        IEventHandler<AuthorBookStartPriceChangedEvent>
    {
        IAuthorEventRepository repo;
        public AuthorBookStartPriceChangedEventHandler(IAuthorEventRepository repo)
        {
            this.repo = repo;
        }
        public Task HandleAsync(AuthorBookStartPriceChangedEvent ev)
        {
            repo.New(AuthorEventType.CostChanged, ev.AuthorId, ev.OldVersion, ev.NewVersion, ev.NewBookStartPrice);
            return Task.CompletedTask;
        }
    }
}
