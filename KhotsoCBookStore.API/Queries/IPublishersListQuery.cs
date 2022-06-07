using DDD.ApplicationLayer;
using KhotsoCBookStore.API.Models.Publishers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KhotsoCBookStore.API.Queries
{
    public interface IPublishersListQuery: IQuery
    {
        Task<IEnumerable<PublisherInfosViewModel>> GetAllPublishers();
        Task<PublisherInfosViewModel> GetPublisherById(int PublisherId);
        
    }
}
