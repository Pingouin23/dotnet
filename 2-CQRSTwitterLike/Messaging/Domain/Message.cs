using System;

namespace Messaging.Domain
{
    public class Message
    {
        private int _messageId;
        private UserId _authorId;

        public void Publish(DateTime publishDate, UserId authorId, string content, int messageId, IEventPublisher eventPublisher)
        {
            MessagePublished message = new MessagePublished(publishDate, authorId,content,messageId);
            if (message.Content.Length > 140)
            {
                throw new MessageTooLong();
            }
            eventPublisher.Publish(message);
            _messageId = message.MessageId;
            _authorId = message.AuthorId;
        }

        public void RePublish(UserId republisherId, IEventPublisher eventPublisher)
        {

            MessageRepublished messageR = new MessageRepublished(republisherId, _messageId);

            if (_authorId.Equals(default(UserId)))
            {
                throw new RepublishWithoutPublished();
            }


            if (republisherId.Equals(_authorId))
            {
                throw new RepublishToSelf();
            }

            eventPublisher.Publish(messageR);
        }

    }
}
