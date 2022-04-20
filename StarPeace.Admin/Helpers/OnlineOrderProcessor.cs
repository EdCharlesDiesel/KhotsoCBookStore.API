using StarPeace.Admin.Contexts;
using StarPeace.Admin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeace.Admin.Helpers
{
    public class OnlineOrderProcessor : OrderProcessor
    {
        readonly StarPeaceAdminDbContext _dbContext;
        public OnlineOrderProcessor(StarPeaceAdminDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
        }
        public override void ValidateOrder()
        {
            OrderLog log = new OrderLog();
            log.OrderId = this.orderId;
            log.Status = "Order has been validated against availity";
            _dbContext.OrderLogs.Add(log);
            _dbContext.SaveChanges();
        }

        public override void ValidatePayment()
        {
            OrderLog log = new OrderLog();
            log.OrderId = this.orderId;
            log.Status = "The credit card has been charged successfully.";
            _dbContext.OrderLogs.Add(log);
            _dbContext.SaveChanges();
        }

        public override void Pack()
        {
            OrderLog log = new OrderLog();
            log.OrderId = this.orderId;
            log.Status = "Packaging department has been notified.";
            _dbContext.OrderLogs.Add(log);
            _dbContext.SaveChanges();
        }

        public override void Ship()
        {
            OrderLog log = new OrderLog();
            log.OrderId = this.orderId;
            log.Status = "Order has been shipped to the customer's address.";
            _dbContext.OrderLogs.Add(log);
            _dbContext.SaveChanges();            
        }
    }
}
