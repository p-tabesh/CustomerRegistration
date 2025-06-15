namespace CustomerRegistration.Core.Event;

public class CustomerRegistredEvent : IEvent
{
    public int CustomerId { get; set; }
    public string Email { get; set; }
    public string Key => CustomerId.ToString();
    public DateTime OccuredAt => DateTime.Now;

    public CustomerRegistredEvent(int customerId, string email)
    {
        CustomerId = customerId;
        Email = email;
    }
}
