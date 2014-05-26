using System.Collections;
using System.Collections.Generic;

using Autofac;

namespace CrowfoundingHn.Common
{
    public class AutoFacDomainEventDispatcher:IDomainEvent
    {
        readonly ILifetimeScope _lifetimeScope;

        public AutoFacDomainEventDispatcher(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }

        public void Raise(IEvent @event)
        {
            var typeOfEvent = @event.GetType();
            var typeOfEventHandler =  typeof(IEventHandler<>).MakeGenericType(typeOfEvent);
            var typeOfService = typeof(IEnumerable<>).MakeGenericType(typeOfEventHandler);
            var handlers = (IEnumerable)_lifetimeScope.Resolve(typeOfService);

            foreach (dynamic handler in handlers)
            {
                handler.Handle((dynamic)@event);
            }
        }
    }
}