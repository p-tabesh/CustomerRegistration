using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace CustomerRegistration.Adapter.Context;

public static class DependecyInjection
{
    public static IServiceCollection AddCustomerDbContext(this IServiceCollection services)
    {
        services.AddDbContext<CustomerRegistrationDbContext>(options =>
        {
            options.UseSqlServer("Data Source=.;Initial Catalog=CustomerRegistrationDb;Integrated Security=True;MultipleActiveResultSets=True; TrustServerCertificate=True");
        });

        return services;
    }
}
