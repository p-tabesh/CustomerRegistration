using CustomerRegistration.Core.Exception;
using CustomerRegistration.Core.IRepository;
using CustomerRegistration.Core.ValueObject;
using CustomerRegistration.UseCase.Model;

namespace CustomerRegistration.UseCase.Customer;

public class CustomerUseCase : ICustomerUseCase
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerUseCase(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public void ChangeEmail(ChangeEmailRequest request)
    {
        var nationalCode = NationalCode.Create(request.NationalCode);
        var customer = _customerRepository.GetByNationalCode(nationalCode) ?? throw new CustomException("Customer Doesn't exists");
        var email = Email.Create(request.NewEmail);
        customer.ChangeEmail(email);
    }

    public void ChangePhoneNumber(ChangePhoneNumberRequest request)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Core.Entity.Customer> GetAllCustomers()
    {
        throw new NotImplementedException();
    }

    public Core.Entity.Customer GetCustomerById(int id)
    {
        throw new NotImplementedException();
    }

    public Core.Entity.Customer GetCustomerByNationalCode(string nationalCode)
    {
        throw new NotImplementedException();
    }

    public Core.Entity.Customer GetCustomerByPhoneNumber(string phoneNumber)
    {
        throw new NotImplementedException();
    }

    public void Register(RegistrationRequest request)
    {
        throw new NotImplementedException();
    }
}
