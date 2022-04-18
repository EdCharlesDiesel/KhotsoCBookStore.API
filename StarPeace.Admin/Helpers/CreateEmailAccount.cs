using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using Microsoft.EntityFrameworkCore;
using StarPeace.Admin.Services;

namespace StarPeace.Admin.Helpers
{

    public class CreateEmailAccount :ICommand
    {
        private EmployeeManager manager;

        public CreateEmailAccount(EmployeeManager manager)
        {
            this.manager = manager;
        }

        public void Execute()
        {
            manager.CreateEmailAccount();
        }

        public void Undo()
        {
            manager.UndoCreateEmailAccount();
        }

    }
}
