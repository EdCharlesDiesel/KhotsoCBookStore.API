using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KhotsoCBookStore.API.Entities;

namespace KhotsoCBookStore.API.Services
{
    public interface IOrderProcessor
    {
        bool ValidateShippingAddress(Address obj);
        void ProcessOrder(Order obj);
    }

    public interface IOnlineOrderProcessor
    {
        bool ValidateCardInfo(CardInfo obj);
    }

}
