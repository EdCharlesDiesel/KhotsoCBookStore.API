using StarPeace.Admin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeace.Admin.Helpers
{
    public class Switchboard
    {
        private ISwitchboardVisitor visitor;

        public List<ISwitchboardItem> Items { get; set; } = new List<ISwitchboardItem>();

        public Switchboard(ISwitchboardVisitor visitor)
        {
            this.visitor = visitor;
        }

        public double Calculate()
        {
            double totalCost = 0;
            foreach (ISwitchboardItem item in Items)
            {
                totalCost += item.Accept(visitor);
            }
            return totalCost;
        }
    }
}
