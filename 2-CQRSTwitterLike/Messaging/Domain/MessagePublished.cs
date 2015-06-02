using System;

namespace Messaging.Domain
{
    public struct MessagePublished : IDomainEvent
    {
        private readonly UserId _ownerId;
        private readonly DateTime _publishDate;
        private readonly UserId _authorId;
        private readonly string _content;
        private readonly int _messageId;
        public int NbRepublish { get; set; }

        public MessagePublished(UserId ownerId, DateTime publishDate, UserId authorId, string content, int messageId) : this()
        {
            _ownerId = ownerId;
            _publishDate = publishDate;
            _authorId = authorId;
            _content = content;
            NbRepublish = 0;
            _messageId = messageId;
        }

        public UserId OwnerId
        {
            get { return _ownerId; }
        }

        public string Content
        {
            get { return _content; }
        }

        public int MessageId
        {
            get { return _messageId; }
        }

        public UserId AuthorId
        {
            get { return _authorId; }
        }

        public DateTime PublishDate
        {
            get { return _publishDate; }
        }
    }
}
