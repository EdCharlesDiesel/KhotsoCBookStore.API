using DDD.ApplicationLayer;
using StarPeaceAdminHubDomain.Aggregates;
using StarPeaceAdminHubDomain.Events;
using StarPeaceAdminHubDomain.IRepositories;
using System.Threading.Tasks;

namespace KhotsoCBookStore.API.Handlers
{
    public class AuthorDeleteEventHandler :
        IEventHandler<AuthorDeleteEvent>
    {
        IAuthorEventRepository repo;
        public AuthorDeleteEventHandler(IAuthorEventRepository repo)
        {
            this.repo = repo;
        }
        public Task HandleAsync(AuthorDeleteEvent ev)
        {
            repo.New(AuthorEventType.Deleted, ev.AuthorId, ev.OldVersion);
            return Task.CompletedTask;
        }
    }
}
