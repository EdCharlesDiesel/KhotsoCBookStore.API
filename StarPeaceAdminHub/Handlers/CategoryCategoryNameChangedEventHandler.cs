using DDD.ApplicationLayer;
using StarPeaceAdminHubDomain.Aggregates;
using StarPeaceAdminHubDomain.Events;
using StarPeaceAdminHubDomain.IRepositories;
using System.Threading.Tasks;

namespace StarPeaceAdminHub.Handlers
{
    //9. Domain events are generated during each aggregate process and are added
    // to the aggregates themselves by us calling their AddDomainEvent methods.
    // However, they are not triggered immediately. Usually, they are triggered at
    // the end of all the aggregates' processing and before changes are passed to the
    // database; however, this is not a general rule.
    public class CategoryCategoryNameChangedEventHandler : IEventHandler<CategoryCategoryNameChangedEvent>
    {
        ICategoryEventRepository repo;
        public CategoryCategoryNameChangedEventHandler(ICategoryEventRepository repo)
        {
            this.repo = repo;
        }
        public Task HandleAsync(CategoryCategoryNameChangedEvent ev)
        {
            repo.New(CategoryEventType.CategoryNameChanged, ev.CategoryId, ev.OldVersion, ev.NewVersion, ev.CategoryName);
            return Task.CompletedTask;
        }
    }
}
