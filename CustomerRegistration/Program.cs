using CustomerRegistration.Adapter.Repository;
using CustomerRegistration.Adapter.Service;
using CustomerRegistration.Core.IRepository;
using CustomerRegistration.Core.IService;
using CustomerRegistration.UseCase.Customer;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddScoped<ICustomerUseCase, CustomerUseCase>();
services.AddScoped<ICustomerRepository,CustomerRepository>();
services.AddScoped<INotificationSender, EmailNotificationSender>();
