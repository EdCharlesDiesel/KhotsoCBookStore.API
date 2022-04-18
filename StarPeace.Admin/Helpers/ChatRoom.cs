using StarPeace.Admin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeace.Admin.Helpers
{
    public class ChatRoom : IChatRoom
    {
        private static Dictionary<string, IParticipant> participants = new Dictionary<string, IParticipant>();

        public void Login(IParticipant participant)
        {
            if (!participants.ContainsKey(participant.Name))
            {
                participants.Add(participant.Name, participant);
            }
        }

        public void Logout(IParticipant participant)
        {
            if (participants.ContainsKey(participant.Name))
            {
                participants.Remove(participant.Name);
            }
        }

        public IParticipant GetParticipant(string name)
        {
            if (participants.ContainsKey(name))
            {
                return participants[name];
            }
            else
            {
                return null;
            }
        }

        public void Send(string from, string to, string message)
        {
            IParticipant target = participants[to];
            if (target != null)
            {
                target.Receive(from, message);
            }
            else
            {
                throw new Exception("Invalid chat participant!");
            }
        }
    }
}
