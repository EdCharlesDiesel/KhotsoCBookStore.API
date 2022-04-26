using DDD.ApplicationLayer;
using StarPeaceAdminHubDomain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeaceAdminHub.Commands
{
    public class CreateBookCommand: ICommand
    {
        public CreateBookCommand(IBookFullEditDTO values)
        {
            Values = values;
        }
        public IBookFullEditDTO Values { get; private set; }
    }
}
