using DDD.ApplicationLayer;
using StarPeaceAdminHubDomain.Aggregates;
using StarPeaceAdminHubDomain.Events;
using StarPeaceAdminHubDomain.IRepositories;
using System.Threading.Tasks;

namespace StarPeaceAdminHub.Handlers
{
    public class CategoryDeleteEventHandler :
        IEventHandler<CategoryDeleteEvent>
    {
        ICategoryEventRepository repo;
        public CategoryDeleteEventHandler(ICategoryEventRepository repo)
        {
            this.repo = repo;
        }
        public Task HandleAsync(CategoryDeleteEvent ev)
        {
            repo.New(CategoryEventType.Deleted, ev.CategoryId, ev.OldVersion);
            return Task.CompletedTask;
        }
    }
}
