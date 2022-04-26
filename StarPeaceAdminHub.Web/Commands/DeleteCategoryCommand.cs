using DDD.ApplicationLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeaceAdminHub.Commands
{
    public class DeleteCategoryCommand: ICommand
    {
        public DeleteCategoryCommand(int id)
        {
            CategoryId = id;
        }
        public int CategoryId { get; private set; }
    }
}
