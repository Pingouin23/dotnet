using System;
using System.Collections;
using System.Collections.Generic;

namespace Messaging.Domain
{
    public struct TimelineMessage// : IEnumerable<TimelineMessage>
    {
        private readonly UserId _ownerId;
        private readonly DateTime _publishDate;
        private readonly UserId _authorId;
        private readonly string _content;
        public int _nbRepublish
        {
            get;
            set;
        }

        public TimelineMessage(UserId ownerId, DateTime publishDate, UserId authorId, string content, int nbRepublish) : this()
        {
            _ownerId = ownerId;
            _publishDate = publishDate;
            _authorId = authorId;
            _content = content;
            _nbRepublish = nbRepublish;
        }

        public TimelineMessage(MessagePublished message) : this()
        {
            _publishDate = message.PublishDate;
            _authorId = message.AuthorId;
            _content = message.Content;
            _nbRepublish = message.NbRepublish;
        }

        public UserId OwnerId
        {
            get { return _ownerId; }
        }

        public DateTime PublishDate
        {
            get { return _publishDate; }
        }

        public UserId AuthorId
        {
            get { return _authorId; }
        }

        public string Content
        {
            get { return _content; }
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable) _content).GetEnumerator();
        }
    }
}