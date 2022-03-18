using System;
using System.Threading.Tasks;

namespace KhotsoCBookStore.API.Services
{
    public interface IWishListService
    {
        Task ToggleWishListItem(Guid customerId, Guid bookId);
        Task<int> ClearWishList(Guid customerId);
        Task<string> GetWishListId(Guid customerId);
    }
}
