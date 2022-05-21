using DDD.ApplicationLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhotsoCBookStore.API.Commands
{
    public class DeleteAuthorCommand: ICommand
    {
        public DeleteAuthorCommand(int id)
        {
            AuthorId = id;
        }
        public int AuthorId { get; private set; }
    }
}
