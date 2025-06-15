using CustomerRegistration.Adapter.Context;
using CustomerRegistration.Core.Entity;
using CustomerRegistration.Core.IRepository;

namespace CustomerRegistration.Adapter.Repository;

class OutboxRepository : CrudRepository<EventOutbox>, IOutboxRepository
{
    public OutboxRepository(CustomerRegistrationDbContext dbContext)
        : base(dbContext)
    {

    }
    public IEnumerable<EventOutbox> GetUnSentEvents()
    {
        var unSentEvents = Entities.Where(e => e.IsSent == false).ToList();
        return unSentEvents;
    }
}
