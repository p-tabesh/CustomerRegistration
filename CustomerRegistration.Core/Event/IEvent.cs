namespace CustomerRegistration.Core.Event;

public interface IEvent
{
    public string Key { get; }
    public DateTime OccuredAt { get; }
}

