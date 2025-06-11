using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerRegistration.Adapter.Context;

public static class DependecyInjection
{
    public static IServiceCollection AddCustomerDbContext(this IServiceCollection services)
    {
        services.AddDbContext<CustomerRegistrationDbContext>(options =>
        {
            options.UseSqlite("Data Source=customerdb.db");
        });

        return services;
    }
}
