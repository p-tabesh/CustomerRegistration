using Confluent.Kafka;

namespace CustomerRegistration.Kafka.Consumer
{
    public class CustomerRegistrationConsumer
    {
        private IConsumer<string, byte[]> _consumer;
        private readonly ConsumerConfiguration _consumerConfig;

        public CustomerRegistrationConsumer(ConsumerConfiguration consumerConfig)
        {
            _consumerConfig = consumerConfig;
        }

        public IConsumer<string, byte[]> Create(string topic)
        {
            _consumer = new ConsumerBuilder<string, byte[]>(_consumerConfig).Build();
            _consumer.Subscribe(topic);
            return _consumer;
        }
    }
}
