using GroupApp.Delivery.Domain.Interfaces.Repositories;
using GroupApp.Delivery.Infrastructure.Database.Postgres.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace GroupApp.Delivery.Infrastructure.Database.Postgres.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services)
    {
        services.AddScoped<IOrderRepository, OrderRepository>();

        return services;
    }
}
