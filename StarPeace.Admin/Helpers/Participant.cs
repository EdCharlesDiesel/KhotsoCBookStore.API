using StarPeace.Admin.Contexts;
using StarPeace.Admin.Entities;
using StarPeace.Admin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeace.Admin.Helpers.Core
{
    public class Participant : IParticipant
    {
        private IChatRoom chatroom;

        readonly StarPeaceAdminDbContext _dbContext;

        public string Name { get; set; }

        public Participant(string name, IChatRoom chatroom, StarPeaceAdminDbContext dbContext)
        {
            this.Name = name;
            this.chatroom = chatroom;
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
        }

        public void Send(string to, string message)
        {
            chatroom.Send(this.Name, to, message);
        }

        public void Receive(string from, string message)
        {
            ChatMessage msg = new ChatMessage();
            msg.From = from;
            msg.To = this.Name;
            msg.Message = message;
            msg.SentOn = DateTime.Now;
           
                _dbContext.ChatMessages.Add(msg);
                _dbContext.SaveChanges();
            
        }

        public List<ChatMessage> GetChatHistory()
        {       
            var query = from m in _dbContext.ChatMessages
                        where m.To == Name || m.From == Name
                        orderby m.SentOn ascending
                        select m;
            return query.ToList();
        }
    }
}
