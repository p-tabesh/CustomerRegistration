using CustomerRegistration.Core.Event;

namespace CustomerRegistration.Kafka.Consumer;

public class CustomerRegistredEventHandler : IEventHandler<CustomerRegistredEvent>
{
    public Task HandleAsync(CustomerRegistredEvent @event)
    {
        Console.WriteLine($"Email sending to {@event.Email}");
        return Task.CompletedTask;
    }
}
