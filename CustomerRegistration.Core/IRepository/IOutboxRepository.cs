using CustomerRegistration.Core.Entity;

namespace CustomerRegistration.Core.IRepository;

public interface IOutboxRepository:ICrudRepository<EventOutbox>
{
    IEnumerable<EventOutbox> GetUnSentEvents();
}
