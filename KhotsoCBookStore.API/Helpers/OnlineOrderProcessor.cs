using KhotsoCBookStore.API.Entities;
using KhotsoCBookStore.API.Services;

namespace KhotsoCBookStore.API.Helpers
{
    public class OnlineOrderProcessor:IOrderProcessor,IOnlineOrderProcessor
    {
        public bool ValidateCardInfo(CardInfo obj)
        {
            //validate credit card information
            return true;
        }

        public bool ValidateShippingAddress(Address obj)
        {
            //validate shipping destination
            return true;
        }

        public void ProcessOrder(Order obj)
        {
            //do something with obj
        }

    }
}
