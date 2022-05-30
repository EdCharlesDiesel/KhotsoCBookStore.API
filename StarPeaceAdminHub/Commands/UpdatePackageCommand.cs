using DDD.ApplicationLayer;
using StarPeaceAdminHubDomain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace StarPeaceAdminHub.Commands
{
    public class UpdatePackageCommand: ICommand
    {
        public UpdatePackageCommand(IPackageFullEditDTO updates)
        {
            Updates = updates;
        }
        public IPackageFullEditDTO Updates { get; private set; }
    }
}
