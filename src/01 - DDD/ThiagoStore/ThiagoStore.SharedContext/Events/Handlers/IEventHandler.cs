namespace ThiagoStore.SharedContext.Events.Handlers
{
    public interface IEventHandler<in T> where T : IDomainEvent
    {
        void Handle(T command);
    }
}
