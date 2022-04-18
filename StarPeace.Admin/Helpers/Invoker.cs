using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using StarPeace.Admin.Services;


namespace StarPeace.Admin.Helpers
{
    public class Invoker
    {
        public List<ICommand> Commands { get; set; } = new List<ICommand>();
        
        public void Execute()
        {
            try
            {
                foreach (ICommand command in Commands)
                {
                    command.Execute();
                }
            }
            catch
            {
                foreach (ICommand command in Commands)
                {
                    command.Undo();
                }
            }
        }
    }
}
