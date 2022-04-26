using DDD.ApplicationLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeaceAdminHub.Commands
{
    public class DeleteCategoryCommand: ICommand
    {
        public DeleteCategoryCommand(Guid id)
        {
            CategoryId = id;
        }
        public Guid CategoryId { get; private set; }
    }
}
