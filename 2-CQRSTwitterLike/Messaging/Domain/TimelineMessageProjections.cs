using Messaging.Tests.Domain;

namespace Messaging.Domain
{
    public class TimelineMessageProjections
    {
        private readonly ITimelineMessageRepository _timelineMessageRepository;

        public TimelineMessageProjections(ITimelineMessageRepository timelineMessageRepository)
        {
            _timelineMessageRepository = timelineMessageRepository;
        }

        public void Handle(MessagePublished messagePublished)
        {
            TimelineMessage lala = new TimelineMessage(messagePublished);
            _timelineMessageRepository.Save(lala);
        }
        public void Republished(MessagePublished messagePublished)
        {
            TimelineMessage lala = new TimelineMessage(messagePublished);
            _timelineMessageRepository.IncrementRepublish(lala);
        }
    }
}
