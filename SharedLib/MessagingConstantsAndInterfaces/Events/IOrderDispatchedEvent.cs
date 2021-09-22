using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingInterfacesConstants.Events
{
    public interface   IOrderDispatchedEvent
    {
        Guid OrderId { get; }

        DateTime DispatchDateTime { get; }
    }
}
