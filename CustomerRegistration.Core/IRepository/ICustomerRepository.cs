using CustomerRegistration.Core.Entity;
using CustomerRegistration.Core.ValueObject;

namespace CustomerRegistration.Core.IRepository;

public interface ICustomerRepository : ICrudRepository<Customer>
{
    Customer GetByNationalCode(NationalCode nationalCode);
    Customer GetByPhoneNumber(PhoneNumber phoneNumber);
    Customer GetByEmail(Email email);
    Customer GetByNationalCodeAndPhoneNumber(NationalCode nationalCode, PhoneNumber phoneNumber);
}
