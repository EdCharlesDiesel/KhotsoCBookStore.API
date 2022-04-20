using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeace.Admin.Services
{
    public interface IChatRoom
    {
        void Login(IParticipant participant);
        void Logout(IParticipant participant);
        void Send(string from, string to, string message);
    }
}
