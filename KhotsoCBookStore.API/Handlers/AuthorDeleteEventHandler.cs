using DDD.ApplicationLayer;
using System.Threading.Tasks;
using StarPeaceAdminHubDomain.Events;
using StarPeaceAdminHubDomain.Aggregates;
using StarPeaceAdminHubDomain.IRepositories;

namespace KhotsoCBookStore.API.Handlers
{
    public class AuthorDeleteEventHandler :
        IEventHandler<AuthorDeleteEvent>
    {
        private readonly IAuthorEventRepository repo;
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
