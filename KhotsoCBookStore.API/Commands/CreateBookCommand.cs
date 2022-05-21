using DDD.ApplicationLayer;
using StarPeaceAdminHubDomain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhotsoCBookStore.API.Commands
{
    //3. They are used to fill the properties of a command object.
    public class CreateBookCommand: ICommand
    {
        public CreateBookCommand(IBookFullEditDTO values)
        {
            Values = values;
        }
        public IBookFullEditDTO Values { get; private set; }
    }
}
