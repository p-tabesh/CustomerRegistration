namespace CustomerRegistration.Core.Event;

public abstract class BaseEnvelop
{
    public string Key { get; private set; }
    public Dictionary<string, string> MessageContext { get; private set; }
    public string Topic { get; private set; }
    public DateTime DateTime { get; private set; }

    protected BaseEnvelop(string key, string topic)
    {
        Key = key;
        MessageContext = new();
        Topic = topic;
        DateTime = DateTime.UtcNow;
    }
}
