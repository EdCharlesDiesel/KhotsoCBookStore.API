using DDD.ApplicationLayer;
using AuthorsManagementDomain.IRepositories;
using System.Threading.Tasks;
using StarPeaceAdminHubDomain.Events;
using StarPeaceAdminHubDomain.Aggregates;

namespace AuthorsManagement.Handlers
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
