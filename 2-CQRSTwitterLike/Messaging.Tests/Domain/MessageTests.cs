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
            UserId owner = new UserId("Quentin");
            DateTime date = DateTime.Now;

            message.Publish(owner,date,author,"bonjour",1, eventPublisher);

            var expectedEvent = new MessagePublished(owner, date, author, "bonjour", 1);
            Check.That(eventPublisher.Events).Contains(expectedEvent);
        }

        // TODO : repeat for other commands : RepublishMessage, LikeMessage, DeleteMessage...
    }
}
