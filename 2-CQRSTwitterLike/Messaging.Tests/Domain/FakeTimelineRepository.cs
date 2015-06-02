using Messaging.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Messaging.Tests.Domain
{
    class FakeTimelineRepository : ITimelineMessageRepository
    {
        internal List<TimelineMessage> Messages = new List<TimelineMessage>();

        public IEnumerable<TimelineMessage> GetLastMessagesForUser(UserId userId, int i)
        {
            throw new NotImplementedException();
        }

        public void Save(TimelineMessage timelineMessage)
        {
            Messages.Add(timelineMessage);
        }
        public void IncrementRepublish(TimelineMessage timelineMessage)
        {
            if(Messages.Contains(timelineMessage))
            {
               int index = Messages.IndexOf(timelineMessage);
                TimelineMessage msg = Messages[index];
                msg._nbRepublish++;
            }
        }
    }
}
