using System.Text.Json;

namespace CustomerRegistration.Core.Event;

public class Envelop<T> : BaseEnvelop where T : IEvent
{
    public T Payload { get; private set; }
    public Envelop(T payload, string topic)
        : base(payload.Key, topic)
    {
        Payload = payload;
    }

    public override string ToString()
    {
        var option = new JsonSerializerOptions
        {
            WriteIndented = true
        };
        return JsonSerializer.Serialize(this, option);
    }
}
