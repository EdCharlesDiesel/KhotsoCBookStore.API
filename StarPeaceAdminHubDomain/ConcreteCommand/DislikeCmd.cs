using StarPeaceAdminHubDomain.CommandInterface;
using StarPeaceAdminHubDomain.Receiver;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarPeaceAdminHubDomain.ConcreteCommand
{
    class DislikeCmd : ICommand
    {
        private Book __book;
        public DislikeCmd(Book _book)
        {
            _book = _book;
        }
        public void Execute()
        {
            _book.Dislike();
        }
        public void Undo()
        {
            _book.UndoDislike();
        }
    }
}
