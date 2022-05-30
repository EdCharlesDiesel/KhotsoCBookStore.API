using DDD.ApplicationLayer;
using StarPeaceAdminHubDomain.Aggregates;
using StarPeaceAdminHubDomain.Events;
using StarPeaceAdminHubDomain.IRepositories;
using System.Threading.Tasks;

namespace KhotsoCBookStore.API.Handlers
{
    public class AuthorPriceChangedEventHandler :
        IEventHandler<AuthorBookStartPriceChangedEvent>
    {
        private readonly IAuthorEventRepository repo;
        public AuthorPriceChangedEventHandler(IAuthorEventRepository repo)
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
