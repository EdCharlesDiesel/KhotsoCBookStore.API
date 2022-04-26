using DDD.ApplicationLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeaceAdminHub.Commands
{
    public class DeleteBookCommand: ICommand
    {
        public DeleteBookCommand(Guid id)
        {
            BookId = id;
        }
        public Guid BookId { get; private set; }
    }
}
