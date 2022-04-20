using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StarPeace.Admin.Entities;
using StarPeace.Admin.Contexts;

namespace StarPeace.Admin.Helpers
{
    public class EmployeeManager
    {
        
        private int employeeId;
        readonly StarPeaceAdminDbContext _dbContext;

        public EmployeeManager(int employeeid,StarPeaceAdminDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
            this.employeeId = employeeid ?? throw new ArgumentNullException(nameof(_dbContext));
        }

        public void CreateEmailAccount()
        {
            CommandQueueItem item = new CommandQueueItem();
            item.EmployeeId = this.employeeId;
            item.CommandText = "EMAIL_ACCOUNT";
            _dbContext.CommandQueues.Add(item);
            _dbContext.SaveChanges();
            
        }

        public void UndoCreateEmailAccount()
        {
            CommandQueueItem item = _dbContext.CommandQueues.Where(i => i.EmployeeId == employeeId && i.CommandText == "EMAIL_ACCOUNT").SingleOrDefault();
            if (item != null)
            {
                _dbContext.Entry(item).State = EntityState.Deleted;
                _dbContext.SaveChanges();
            }
            
        }

        public void OrderVisitingCards()
        {
            CommandQueueItem item = new CommandQueueItem();
            item.EmployeeId = this.employeeId;
            item.CommandText = "VISITING_CARDS";
            _dbContext.CommandQueues.Add(item);
            _dbContext.SaveChanges();
        }

        public void UndoOrderVisitingCards()
        {
            CommandQueueItem item = _dbContext.CommandQueue.Where(i => i.EmployeeId == employeeId && i.CommandText == "VISITING_CARDS").SingleOrDefault();
            if (item != null)
            {
                _dbContext.Entry(item).State = EntityState.Deleted;
                _dbContext.SaveChanges();
            }            
        }

        public void PrepareIdentityCard()
        {
            CommandQueueItem item = new CommandQueueItem();
            item.EmployeeId = this.employeeId;
            item.CommandText = "IDENTITY_CARD";
            _dbContext.CommandQueue.Add(item);
            _dbContext.SaveChanges();            
        }

        public void UndoPrepareIdentityCard()
        {
            CommandQueueItem item = _dbContext.CommandQueue.Where(i => i.EmployeeId == employeeId && i.CommandText == "IDENTITY_CARD").SingleOrDefault();
            if (item != null)
            {
                _dbContext.Entry(item).State = EntityState.Deleted;
                _dbContext.SaveChanges();
            }            
        }

    }
}
