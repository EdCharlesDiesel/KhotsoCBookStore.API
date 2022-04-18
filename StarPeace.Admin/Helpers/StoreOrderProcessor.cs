using StarPeace.Admin.Contexts;
using StarPeace.Admin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeace.Admin.Helpers
{
    public class StoreOrderProcessor : OrderProcessor
    {
        readonly StarPeaceAdminDbContext _dbContext;
        public StoreOrderProcessor(StarPeaceAdminDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
        }
        public override void ValidateOrder()
        {          
            OrderLog log = new OrderLog();
            log.OrderId = this.orderId;
            log.Status = "Order has been validated.";
            _dbContext.OrderLog.Add(log);
            _dbContext.SaveChanges();            
        }

        public override void ValidatePayment()
        {
            OrderLog log = new OrderLog();
            log.OrderId = this.orderId;
            log.Status = "The cash payment has been received.";
            _dbContext.OrderLog.Add(log);
            _dbContext.SaveChanges();            
        }

        public override void Pack()
        {
            OrderLog log = new OrderLog();
            log.OrderId = this.orderId;
            log.Status = "The packing personnel have been notified.";
            _dbContext.OrderLog.Add(log);
            _dbContext.SaveChanges();            
        }

        public override void Ship()
        {
            OrderLog log = new OrderLog();
            log.OrderId = this.orderId;
            log.Status = "Order has been sent to the salesman desk.";
            _dbContext.OrderLog.Add(log);
            _dbContext.SaveChanges();            
        }
    }
}
