using System.Collections.Generic;

namespace Messaging.Domain
{
    public interface ITimelineMessageRepository
    {
        IEnumerable<TimelineMessage> GetLastMessagesForUser(UserId userId, int i);
        void Save(TimelineMessage timelineMessage);
        void IncrementRepublish(TimelineMessage timelineMessage);
    }
}