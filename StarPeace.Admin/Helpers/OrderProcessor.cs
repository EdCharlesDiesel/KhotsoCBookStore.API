using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeace.Admin.Helpers
{
    public abstract class OrderProcessor
    {
        protected int orderId;

        public void ProcessOrder(int orderid)
        {
            this.orderId = orderid;
            ValidateOrder();
            ValidatePayment();
            Pack();
            Ship();
        }

        public abstract void ValidateOrder();
        public abstract void ValidatePayment();
        public abstract void Pack();
        public abstract void Ship();
    }
}
