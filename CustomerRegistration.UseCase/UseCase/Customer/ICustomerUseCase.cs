using CustomerRegistration.UseCase.Model;

namespace CustomerRegistration.UseCase.Customer;

public interface ICustomerUseCase
{
    int Register(RegistrationRequest request);
    void ChangePhoneNumber(ChangePhoneNumberRequest request);
    void ChangeEmail(ChangeEmailRequest request);

    IEnumerable<CustomerViewModel> GetAllCustomers();
    CustomerViewModel GetCustomerById(int id);
    CustomerViewModel GetCustomerByNationalCode(string nationalCode);
    CustomerViewModel GetCustomerByPhoneNumber(string phoneNumber);
}
