using System;
using Messaging.Domain;
using NFluent;
using NUnit.Framework;

namespace Messaging.Tests.Domain
{
    [TestFixture]
    public class MessageTests
    {
        [Test]
        public void WhenPublishAMessage_ThenMessagePublishedIsPublished()
        {
            var eventPublisher = new FakeEventPublisher();

            var message = new Message(); // aggregate, NO parameters, never inject in aggregate roots

            UserId author = new UserId("Théo");
            DateTime date = DateTime.Now;

            message.Publish(date,author,"bonjour",1, eventPublisher);

            var expectedEvent = new MessagePublished(date, author, "bonjour", 1);
            Check.That(eventPublisher.Events).Contains(expectedEvent);
        }

        [Test]
        [ExpectedException(typeof(MessageTooLong))]
        public void WhenMessageTooLong()
        {
            var eventPublisher = new FakeEventPublisher();

            var message = new Message(); // aggregate, NO parameters, never inject in aggregate roots

            UserId author = new UserId("Théo");
            DateTime date = DateTime.Now;

            message.Publish(date, author, "bonjour qqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqq", 1, eventPublisher);
        }

        [Test]
        public void WhenRePublishAMessage_ThenMessageRePublishedIsRePublished()
        {
            var eventPublisher = new FakeEventPublisher();

            var message = new Message(); // aggregate, NO parameters, never inject in aggregate roots

            UserId author = new UserId("Théo");
            DateTime date = DateTime.Now;

            message.Publish(date, author, "bonjour", 1, eventPublisher);
            message.RePublish(new UserId("Audrey"), eventPublisher);

            var expectedEvent = new MessageRepublished(new UserId("Audrey"), 1);
            Check.That(eventPublisher.Events).Contains(expectedEvent);
        }

        [Test]
        [ExpectedException(typeof(RepublishToSelf))]
        public void WhenRepublishToSelf()
        {
            var eventPublisher = new FakeEventPublisher();

            var message = new Message();

            UserId author = new UserId("Théo");
            DateTime date = DateTime.Now;

            message.Publish(date, author, "bonjour", 1, eventPublisher);
            message.RePublish(author, eventPublisher);
        }

        [Test]
        [ExpectedException(typeof(RepublishWithoutPublished))]
        public void WhenRepublishWithoutPublished()
        {
            var eventPublisher = new FakeEventPublisher();
            var message = new Message();

            UserId author = new UserId("Théo");

            message.RePublish(author, eventPublisher);
        }
        // TODO : repeat for other commands : RepublishMessage, LikeMessage, DeleteMessage...
    }
}
