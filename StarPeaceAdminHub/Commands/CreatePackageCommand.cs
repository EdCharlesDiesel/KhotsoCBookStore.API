using DDD.ApplicationLayer;
using StarPeaceAdminHubDomain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeaceAdminHub.Commands
{
    public class CreatePackageCommand: ICommand
    {
        public CreatePackageCommand(IPackageFullEditDTO values)
        {
            Values = values;
        }
        public IPackageFullEditDTO Values { get; private set; }
    }
}
