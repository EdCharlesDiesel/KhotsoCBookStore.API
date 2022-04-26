using StarPeaceAdminHubDomain.CommandInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarPeaceAdminHubDomain.Invoker
{
    class CommandInvoker
    {   
        public ICommand Command { get; set; }
        public void Invoke()
        {
            Command.Execute();
        }

        internal void Undo()
        {
            Command.Undo();
        }
    }
}
