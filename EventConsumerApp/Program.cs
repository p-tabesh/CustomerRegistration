using CustomerRegistration.Core.Event;
using CustomerRegistration.Kafka.Consumer;
using CustomerRegistration.KafkaPackage.Consumer;
using System.Reflection;
using System.Text;
using System.Text.Json;

var consumerConfig = new ConsumerConfiguration
{
    Topic = "CustomerRegister",
    BootstrapServers = "localhost:9092",
    GroupId = Assembly.GetExecutingAssembly().FullName,
    
};

var consumer = new CustomerRegistrationConsumer(consumerConfig).Create();

while (true)
{
    var result = consumer.Consume();
    if (!result.IsPartitionEOF && result != null)
    {
        result.Message.Headers.TryGetLastBytes("EventType", out byte[] typeName);
        var eventTypeName = Encoding.UTF8.GetString(typeName);
        var @event = JsonSerializer.Deserialize(result.Message.Value,Type.GetType(eventTypeName));
        Handle((IEvent)@event);
    }

}

// temp event handler
async Task Handle(IEvent @event)
{
    var handler = new CustomerRegistredEventHandler();
    await handler.HandleAsync((CustomerRegistredEvent)@event);
}

