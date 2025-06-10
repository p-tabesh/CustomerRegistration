using CustomerRegistration.UseCase.Model;

namespace CustomerRegistration.UseCase.Customer;

public interface ICustomerUseCase
{
    void Register(RegistrationRequest request);
    void ChangePhoneNumber(ChangePhoneNumberRequest request);
    void ChangeEmail(ChangeEmailRequest request);

    IEnumerable<Core.Entity.Customer> GetAllCustomers();
    Core.Entity.Customer GetCustomerById(int id);
    Core.Entity.Customer GetCustomerByNationalCode(string nationalCode);
    Core.Entity.Customer GetCustomerByPhoneNumber(string phoneNumber);
}
