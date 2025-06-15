namespace CustomerRegistration.Kafka.Consumer;

public class ConsumerConfiguration
{
    public string Topic { get; set; }
    public string BootstrapServers { get; set; }
    public string GroupId { get; set; }
}
