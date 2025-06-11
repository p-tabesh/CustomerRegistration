using CustomerRegistration.Adapter.Context;
using CustomerRegistration.Adapter.Repository;
using CustomerRegistration.Adapter.Service;
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

switch (response)
{
    case "RegisterCustomer":
        RegisterCustomer();
        break;
    case "Change Email":
        RegisterCustomer();
        break;
    case "Change PhoneNumber":
        RegisterCustomer();
        break;
    case "Get All Customers":
        RegisterCustomer();
        break;
    default:
        Console.WriteLine("Invalid Option");
        break;
}

var request = new RegistrationRequest("pooya", "tabi", "0151986843", "09028035128", "test@gmail.com");
customerUseCase.Register(request);


void RegisterCustomer()
{

}

void ChangeEmail()
{

}

void ChangePhoneNumber()
{

}

void GetAllCustomer()
{

}