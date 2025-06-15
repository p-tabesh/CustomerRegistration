using CustomerRegistration.Core.Entity;
using CustomerRegistration.Core.Event;
using CustomerRegistration.Core.Exception;
using CustomerRegistration.Core.IRepository;
using CustomerRegistration.Core.IService;
using CustomerRegistration.Core.ValueObject;
using CustomerRegistration.UseCase.Model;
using System.Text.Json;

namespace CustomerRegistration.UseCase.Customer;

public class CustomerUseCase : ICustomerUseCase
{
    private readonly ICustomerRepository _customerRepository;
    private readonly INotificationSender _notificationSender;
    private readonly IOutboxRepository _outboxRepository;

    public CustomerUseCase(ICustomerRepository customerRepository, IOutboxRepository outboxRepository, INotificationSender notificationSender)
    {
        _customerRepository = customerRepository;
        _notificationSender = notificationSender;
        _outboxRepository = outboxRepository;
    }


    public int Register(RegistrationRequest request)
    {
        var nationalCode = NationalCode.Create(request.NationalCode);
        var phoneNumber = PhoneNumber.Create(request.PhoneNumber);
        var email = Email.Create(request.Email);
        var existCustomer = _customerRepository.GetByNationalCodeAndPhoneNumber(nationalCode, phoneNumber);

        if (existCustomer != null)
            throw new CustomException("Customer already exists");

        var customer = new Core.Entity.Customer(request.Name, request.LastName, nationalCode, phoneNumber, email);
        var @event = new CustomerRegistredEvent(customer.Id, customer.Email.Value);
        var outbox = new EventOutbox(@event.GetType().Name,
                                     @event,
                                     DateTime.Now);

        _customerRepository.Add(customer);
        _outboxRepository.Add(outbox);
        //_notificationSender.Notify(email.ToString());

        return customer.Id;
    }

    public void ChangeEmail(ChangeEmailRequest request)
    {
        var nationalCode = NationalCode.Create(request.NationalCode);
        var customer = _customerRepository.GetByNationalCode(nationalCode) ?? throw new CustomException("Customer Doesn't exists");
        var email = Email.Create(request.NewEmail);
        customer.ChangeEmail(email);

        _customerRepository.Update(customer);
    }

    public void ChangePhoneNumber(ChangePhoneNumberRequest request)
    {
        var nationalCode = NationalCode.Create(request.NationalCode);
        var customer = _customerRepository.GetByNationalCode(nationalCode) ?? throw new CustomException("Customer Doesn't exists");
        var phoneNumber = PhoneNumber.Create(request.newPhoneNumber);
        customer.ChangePhoneNumber(phoneNumber);

        _customerRepository.Update(customer);
    }

    public IEnumerable<CustomerViewModel> GetAllCustomers()
    {
        var customers = _customerRepository.GetAll();
        var models = CustomerViewModel.Parse(customers);
        return models;
    }

    public CustomerViewModel GetCustomerById(int id)
    {
        var customer = _customerRepository.GetById(id) ?? throw new CustomException("Customer doesn't exists");
        var model = CustomerViewModel.Parse(customer);
        return model;
    }

    public CustomerViewModel GetCustomerByNationalCode(string nationalCode)
    {
        var customerNationalCode = NationalCode.Create(nationalCode);
        var customer = _customerRepository.GetByNationalCode(customerNationalCode) ?? throw new CustomException("Customer doesn't exists");

        return CustomerViewModel.Parse(customer);
    }

    public CustomerViewModel GetCustomerByPhoneNumber(string phoneNumber)
    {
        var phone = PhoneNumber.Create(phoneNumber);
        var customer = _customerRepository.GetByPhoneNumber(phone) ?? throw new CustomException("Customer doesn't exists");

        return CustomerViewModel.Parse(customer);
    }
}
