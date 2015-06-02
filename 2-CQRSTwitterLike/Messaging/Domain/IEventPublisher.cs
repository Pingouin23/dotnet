namespace Messaging.Domain
{
    public interface IEventPublisher
    {
        void Publish(IDomainEvent @event);

    }
}
