using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Messaging.Domain;
using NUnit.Framework;

namespace Messaging.Tests.Domain
{
    class FakeEventPublisher : IEventPublisher
    {
        public List<IDomainEvent> Events = new List<IDomainEvent>();
        public void Publish(IDomainEvent @event)
        {
            Events.Add(@event);
        }
    }
}
