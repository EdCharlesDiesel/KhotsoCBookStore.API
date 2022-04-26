using System;
using System.Collections.Generic;
using System.Text;

namespace StarPeaceAdminHubDomain.CommandInterface
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}
