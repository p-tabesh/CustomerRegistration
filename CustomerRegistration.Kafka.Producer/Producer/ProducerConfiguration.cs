namespace CustomerRegistration.KafkaPackage.Producer;

public class ProducerConfiguration
{
    public string Topic { get; set; }
    public int NumberOfPartitions { get; set; }
    public int ReplicationFactor { get; set; }
    public string BootstrapServers { get;set; }
    public string SchemaRegistryServer { get; set; }
}
