using GroupApp.Delivery.Domain.Interfaces.Services;
using GroupApp.Delivery.Infrastructure.Kafka.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GroupApp.Delivery.Infrastructure.Kafka.Extensions;

public static class ServiceCollectionsExtensions
{
    public static IServiceCollection AddKafka(this IServiceCollection services)
    {
        services.AddScoped<IPublisherMessage, PublisherMessage>();

        return services;
    }
}
