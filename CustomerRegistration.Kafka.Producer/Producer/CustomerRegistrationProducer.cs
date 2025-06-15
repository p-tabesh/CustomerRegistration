using Confluent.Kafka;
using Confluent.SchemaRegistry;
using Confluent.SchemaRegistry.Serdes;
using CustomerRegistration.Core.Event;
using System.Text;
using System.Text.Json;

namespace CustomerRegistration.KafkaPackage.Producer;

public class CustomerRegistrationProducer<T> where T : IEvent
{
    private readonly ProducerConfiguration _producerConfig;
    private readonly IProducer<string, T> _producer;
    public CustomerRegistrationProducer(ProducerConfiguration producerConfig)
    {
        var producerCfg = new ProducerConfig()
        {
            BootstrapServers = producerConfig.BootstrapServers
        };

        var schemaClient = new CachedSchemaRegistryClient(new SchemaRegistryConfig()
        {
            Url = producerConfig.SchemaRegistryServer
        });

        _producer = new ProducerBuilder<string, T>(producerCfg)
            .SetValueSerializer(new AvroSerializer<T>(schemaClient))
            .Build();
    }

    public async Task ProduceAsync(T @event, CancellationToken cancellationToken = default)
    {
        var message = new Envelop<T>(@event, _producerConfig.Topic);
        var kafkaMessage = new Message<string, T>
        {
            Value = @event,
            Key = @event.Key.ToString(),
            Headers = new Headers()
        };
        kafkaMessage.Headers.Add("EventType", Encoding.UTF8.GetBytes(@event.GetType().FullName));

        await _producer.ProduceAsync(_producerConfig.Topic, kafkaMessage, cancellationToken);
    }
}
