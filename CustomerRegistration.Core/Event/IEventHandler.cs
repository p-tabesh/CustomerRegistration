namespace CustomerRegistration.Core.Event;

public interface IEventHandler<T> where T : IEvent
{
    public Task HandleAsync(T @event);
}
