using CustomerRegistration.Adapter.Context;
using CustomerRegistration.Core.Entity;
using CustomerRegistration.Core.IRepository;
using CustomerRegistration.Core.ValueObject;

namespace CustomerRegistration.Adapter.Repository;

public class CustomerRepository : CrudRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(CustomerRegistrationDbContext dbContext)
        : base(dbContext) { }

    public Customer GetByEmail(Email email)
    {
        var customer = Entities.FirstOrDefault(c => c.Email == email);
        return customer;
    }

    public Customer GetByNationalCode(NationalCode nationalCode)
    {
        var customer = Entities.FirstOrDefault(c => c.NationalCode == nationalCode);
        return customer;
    }

    public Customer GetByNationalCodeAndPhoneNumber(NationalCode nationalCode, PhoneNumber phoneNumber)
    {
        var customer = Entities.FirstOrDefault(c => c.NationalCode == nationalCode && c.PhoneNumber == phoneNumber);
        return customer;
    }

    public Customer GetByPhoneNumber(PhoneNumber phoneNumber)
    {
        var customer = Entities.FirstOrDefault(c => c.PhoneNumber == phoneNumber);
        return customer;
    }
}
