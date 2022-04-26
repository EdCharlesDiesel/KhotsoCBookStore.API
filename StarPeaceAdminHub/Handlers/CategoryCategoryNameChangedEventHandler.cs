using DDD.ApplicationLayer;
using StarPeaceAdminHubDomain.Aggregates;
using StarPeaceAdminHubDomain.Events;
using StarPeaceAdminHubDomain.IRepositories;
using System.Threading.Tasks;

namespace StarPeaceAdminHub.Handlers
{
    public class CategoryCategoryNameChangedEventHandler :
        IEventHandler<CategoryCategoryNameChangedEvent>
    {
        ICategoryEventRepository repo;
        public CategoryCategoryNameChangedEventHandler(ICategoryEventRepository repo)
        {
            this.repo = repo;
        }
        public Task HandleAsync(CategoryCategoryNameChangedEvent ev)
        {
            repo.New(CategoryEventType.CategoryName, ev.CategoryId, ev.OldVersion, ev.NewVersion, ev.CategoryName);
            return Task.CompletedTask;
        }
    }
}
