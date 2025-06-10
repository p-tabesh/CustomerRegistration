using CustomerRegistration.Core.IRepository;

namespace CustomerRegistration.UseCase.UseCase;

public class CustomerUseCase
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerUseCase(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
}
