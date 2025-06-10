using CustomerRegistration.UseCase.Entity;

namespace CustomerRegistration.UseCase.UseCase.Customer;

public interface ICustomerUseCase
{
    void Register();
    void ChangePhoneNumber();
    void ChangeEmail();
}
