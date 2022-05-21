using DDD.DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.ApplicationLayer
{
    // 1.0 To increase modularity and decoupling, communication among entities
    // is usually encoded with events, that is, with a Publisher/Subscriber pattern.
    // This means entity updates can trigger events that have been hooked to business
    // operations, and these events act on other entities.
    public class EventMediator : IEventMediator
    {
        IServiceProvider services;
        public EventMediator(IServiceProvider services)
        {
            this.services = services;
        }
        public async Task TriggerEvents(IEnumerable<IEventNotification> events)
        {
            if (events == null) return;
            foreach(var ev in events)
            {
                var triggerType = typeof(EventTrigger<>).MakeGenericType(ev.GetType());
                var trigger = services.GetService(triggerType);
                var task = (Task)triggerType.GetMethod(nameof(EventTrigger<IEventNotification>.Trigger))
                    .Invoke(trigger, new object[] { ev });
                await task.ConfigureAwait(false);

            }
        }
    }
}
