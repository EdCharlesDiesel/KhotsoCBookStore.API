using StarPeace.Admin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeace.Admin.Helpers
{
    public class PrepareIdentityCard : ICommand
    {
        private EmployeeManager manager;

        public PrepareIdentityCard(EmployeeManager manager)
        {
            this.manager = manager;
        }

        public void Execute()
        {
            manager.PrepareIdentityCard();
        }

        public void Undo()
        {
            manager.UndoPrepareIdentityCard();
        }
    }
}
