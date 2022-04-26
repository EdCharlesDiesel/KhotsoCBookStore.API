using DDD.ApplicationLayer;
using StarPeaceAdminHubDomain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace StarPeaceAdminHub.Commands
{
    public class UpdateBookCommand: ICommand
    {
        public UpdateBookCommand(IBookFullEditDTO updates)
        {
            Updates = updates;
        }
        public IBookFullEditDTO Updates { get; private set; }
    }
}
