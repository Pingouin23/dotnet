using System;

namespace Messaging.Domain
{
    public class Message
    {
        public void Publish(UserId ownerId, DateTime publishDate, UserId authorId, string content, int messageId, IEventPublisher eventPublisher)
        {
            MessagePublished message = new MessagePublished(ownerId, publishDate, authorId,content,messageId);
            eventPublisher.Publish(message);
        }
    }
}
