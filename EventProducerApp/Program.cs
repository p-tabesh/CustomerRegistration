using CustomerRegistration.Adapter.Context;
using CustomerRegistration.Core.Event;
using CustomerRegistration.KafkaPackage.Producer;
using System.Text.Json;

var producerConfig = new ProducerConfiguration
{
    BootstrapServers = "localhost:9092",
    NumberOfPartitions = 1,
    ReplicationFactor = 1,
    SchemaRegistryServer = "localhost:8082",
    Topic = "Customer-Registered"
};

var producer = new CustomerRegistrationProducer<CustomerRegistredEvent>(producerConfig);
var cts = new CancellationTokenSource();
var dbContext = new CustomerRegistrationDbContext();
var events = dbContext.Outbox.Where(e => e.IsSent == false).ToList();

foreach (var @event in events)
{
    var evnt = (CustomerRegistredEvent)JsonSerializer.Deserialize(@event.EventContent, Type.GetType(@event.EventType));
    producer.ProduceAsync(evnt,cts.Token);
    @event.MessageSent();
}

dbContext.Outbox.UpdateRange(events);