using StarPeace.Admin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeace.Admin.Services
{
    public interface IParticipant
    {
        string Name { get; set; }
        void Send(string to, string message);
        void Receive(string from, string message);
        List<ChatMessage> GetChatHistory();
    }
}
