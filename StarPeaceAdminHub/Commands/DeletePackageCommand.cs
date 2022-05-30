using DDD.ApplicationLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeaceAdminHub.Commands
{
    public class DeletePackageCommand: ICommand
    {
        public DeletePackageCommand(int id)
        {
            PackageId = id;
        }
        public int PackageId { get; private set; }
    }
}
