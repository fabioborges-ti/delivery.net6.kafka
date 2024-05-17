using GroupAdd.Delivery.Consumer.Services;
using GroupApp.Delivery.Domain.Interfaces.Services;

namespace GroupAdd.Delivery.Consumer.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddNotifications(this IServiceCollection services)
    {
        services.AddScoped<INotifierService, NotifierService>();

        return services;
    }
}
