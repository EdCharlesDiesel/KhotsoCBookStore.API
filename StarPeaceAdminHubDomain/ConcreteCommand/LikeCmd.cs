using StarPeaceAdminHubDomain.CommandInterface;
using StarPeaceAdminHubDomain.Receiver;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarPeaceAdminHubDomain.ConcreteCommand
{
    class LikeCmd : ICommand
    {
        private Book _book;
        public LikeCmd(Book book)
        {
            _book = book;
        }
        public void Execute()
        {
            _book.Like();
        }

        public void Undo()
        {
            _book.UndoLike();
        }
    }
}
