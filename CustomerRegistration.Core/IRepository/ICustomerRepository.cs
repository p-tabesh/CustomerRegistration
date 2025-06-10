using CustomerRegistration.UseCase.Entity;

namespace CustomerRegistration.Core.IRepository;

public interface ICustomerRepository:ICrudRepository<Customer>
{
    Customer GetByNationalCode(string nationalCode);
    Customer GetByPhoneNumber(string phoneNumber);
    Customer GetByEmail(string email);
}
