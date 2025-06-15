using CustomerRegistration.Core.Event;
using System.Text.Json;

namespace CustomerRegistration.Core.Entity;

public class EventOutbox
{
    public int Id { get; private set; }
    public string EventType { get; private set; }
    public string EventContent { get; private set; }
    public DateTime EventDateTime { get; private set; }
    public DateTime CreationDateTime { get; private set; }
    public bool IsSent { get; private set; }

    public EventOutbox(string eventType, IEvent eventContent, DateTime eventDateTime)
    {
        EventType = eventType;
        EventContent = JsonSerializer.Serialize(eventContent);
        EventDateTime = eventDateTime;
        CreationDateTime = DateTime.Now;
        IsSent = false;
    }

    public void MessageSent()
    {
        IsSent = true;
    }
}
