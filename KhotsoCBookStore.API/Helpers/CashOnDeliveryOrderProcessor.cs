using KhotsoCBookStore.API.Entities;
using KhotsoCBookStore.API.Services;

namespace KhotsoCBookStore.API.Helpers
{
    public class CashOnDeliveryOrderProcessor:IOrderProcessor
    {
       
        //public bool ValidateCardInfo(CardInfo obj)
        //{
        //    throw new NotImplementedException();
        //}

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
