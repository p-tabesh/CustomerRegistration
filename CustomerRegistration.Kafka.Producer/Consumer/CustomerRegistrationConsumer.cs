using Confluent.Kafka;
using CustomerRegistration.Core.Event;

namespace CustomerRegistration.KafkaPackage.Consumer
{
    public class CustomerRegistrationConsumer
    {
        private IConsumer<string, byte[]> _consumer;
        private readonly ConsumerConfig _consumerConfig;
        private readonly string _topic;

        public CustomerRegistrationConsumer(ConsumerConfiguration consumerConfig)
        {
            _consumerConfig = new ConsumerConfig
            {
                GroupId = consumerConfig.GroupId,
                BootstrapServers = consumerConfig.BootstrapServers
            };
            _topic = consumerConfig.Topic;
        }

        public IConsumer<string, byte[]> Create()
        {
            _consumer = new ConsumerBuilder<string, byte[]>(_consumerConfig).Build();
            _consumer.Subscribe(_topic);
            return _consumer;
        }
    }
}
