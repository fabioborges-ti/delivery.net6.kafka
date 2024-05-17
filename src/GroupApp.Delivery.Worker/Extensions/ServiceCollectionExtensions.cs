using GroupApp.Delivery.Domain.Interfaces.Services;
using GroupApp.Delivery.Worker.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GroupApp.Delivery.Worker.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddNotifications(this IServiceCollection services)
    {
        services.AddScoped<INotifierService, NotifierService>();

        return services;
    }

}
