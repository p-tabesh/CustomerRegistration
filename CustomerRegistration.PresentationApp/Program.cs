using CustomerRegistration.Adapter.Context;
using CustomerRegistration.Adapter.Repository;
using CustomerRegistration.Adapter.Service;
using CustomerRegistration.Core.Exception;
using CustomerRegistration.Core.IRepository;
using CustomerRegistration.Core.IService;
using CustomerRegistration.UseCase.Customer;
using CustomerRegistration.UseCase.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddScoped<ICustomerUseCase, CustomerUseCase>();
services.AddScoped<ICustomerRepository, CustomerRepository>();
services.AddScoped<INotificationSender, EmailNotificationSender>();
services.AddDbContext<CustomerRegistrationDbContext>(options =>
{
    options.UseSqlite("Data Source=customerdb.db");
});

var serviceProvider = services.BuildServiceProvider();
serviceProvider.GetRequiredService<CustomerRegistrationDbContext>();


var customerUseCase = serviceProvider.GetService<ICustomerUseCase>();

Console.WriteLine("Select Action");
Console.WriteLine("1. RegisterCustomer");
Console.WriteLine("2. Change Email");
Console.WriteLine("3. Change PhoneNumber");
Console.WriteLine("4. Get All Customers");
var response = Console.ReadLine();

try
{
    switch (response)
    {
        case "RegisterCustomer":
            RegisterCustomer();
            break;
        case "Change Email":
            ChangeEmail();
            break;
        case "Change PhoneNumber":
            ChangePhoneNumber();
            break;
        case "Get All Customers":
            GetAllCustomers();
            break;
        default:
            Console.WriteLine("Invalid Option");
            break;
    }
}
catch (CustomException ex)
{
    Console.WriteLine(ex.Message);
    throw;
}
catch (Exception)
{
    Console.WriteLine("Somthing went wrong.");
    throw;
}




void RegisterCustomer()
{
    var request = new RegistrationRequest("pooya", "tabi", "0151986843", "09028035128", "test@gmail.com");
    var result = customerUseCase.Register(request);
    Console.WriteLine($"Customer Created Successfully: CustomerId = {result}");
}

void ChangeEmail()
{
    var request = new ChangeEmailRequest("0151986843","newemail@gmail.com");
    customerUseCase.ChangeEmail(request);
    Console.WriteLine("Email changed successfully");
}

void ChangePhoneNumber()
{
    var request = new ChangePhoneNumberRequest("0151986843","09904687013");
    customerUseCase.ChangePhoneNumber(request);
    Console.WriteLine("PhoneNumber changed successfully");
}

void GetAllCustomers()
{
    var customers = customerUseCase.GetAllCustomers();
    foreach (var customer in customers)
    {
        Console.WriteLine(customer);
    }
}