using System;
using Messaging.Domain;
using NFluent;
using NUnit.Framework;

namespace Messaging.Tests.Domain
{
    [TestFixture]
    public class TimelineMessageProjectionsTests
    {
        [Test]
        public void WhenHandleMessagePublished_ThenTimelineMessageIsSavedForAuthor()
        {
            UserId userid1 = new UserId("quentin");
            UserId userid2 = new UserId("audrey");
            var messagePublished = new MessagePublished(userid1, DateTime.Now, userid2, "Salut", 1);
            // TODO : FakeTimelineRepository is a fake implementation of interface for tests purpose only -> keep it in test assembly
            var timelineMessageRepositoryFake = new FakeTimelineRepository();
            var timelineMessageProjections = new TimelineMessageProjections(timelineMessageRepositoryFake);

            timelineMessageProjections.Handle(messagePublished);

            var expectedTimelineMessage = new TimelineMessage(messagePublished);
            Check.That(timelineMessageRepositoryFake.Messages).ContainsExactly(expectedTimelineMessage);
        }

        [Test]
        public void WhenHandleMessageRePublished()
        {
            UserId userid1 = new UserId("quentin");
            UserId userid2 = new UserId("audrey");
            var messagePublished = new MessagePublished(userid1, DateTime.Now, userid2, "Salut", 1);
            var timelineMessageRepositoryFake = new FakeTimelineRepository();
            var timelineMessageProjections = new TimelineMessageProjections(timelineMessageRepositoryFake);

            timelineMessageProjections.Handle(messagePublished);

            var expectedTimelineMessage = new TimelineMessage(messagePublished);
            Check.That(timelineMessageRepositoryFake.Messages[timelineMessageRepositoryFake.Messages.IndexOf(new TimelineMessage(messagePublished))]._nbRepublish).Equals(expectedTimelineMessage._nbRepublish);
        }

        //TODO : repeat for some more Events : FollowerMessagePublished, FollowerMessageRepublished, FollowerMessageLiked, MessageDeleted...
    }
}
