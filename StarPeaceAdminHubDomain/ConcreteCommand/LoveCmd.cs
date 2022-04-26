using StarPeaceAdminHubDomain.CommandInterface;
using StarPeaceAdminHubDomain.Receiver;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarPeaceAdminHubDomain.ConcreteCommand
{
    class LoveCmd : ICommand
    {
        private Book _book;
        public LoveCmd(Book book)
        {
            _book = book;
        }
        public void Execute()
        {
            _book.Love();
        }
        public void Undo()
        {
            _book.UndoLove();
        }
    }
}
