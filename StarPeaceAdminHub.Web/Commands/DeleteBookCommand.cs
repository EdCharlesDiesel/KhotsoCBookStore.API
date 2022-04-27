using DDD.ApplicationLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeaceAdminHub.Commands
{
    public class DeleteBookCommand: ICommand
    {
        public DeleteBookCommand(int id)
        {
            BookId = id;
        }
        public int BookId { get; private set; }
    }
}
