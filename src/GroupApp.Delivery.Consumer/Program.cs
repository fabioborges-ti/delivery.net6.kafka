using GroupApp.Delivery.Consumer;
using GroupApp.Delivery.Consumer.Extensions;
using GroupApp.Delivery.Infrastructure.Kafka.Settings;

class Program
{
    static void Main(string[] args)
    {
        using IHost host = CreateHostBuilder(args).Build();

        var config = host.Services.GetRequiredService<IConfiguration>();

        host.Run();
    }

    static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddNotifications();
                services.Configure<OrderSettings>(hostContext.Configuration.GetSection("OrderSettings"));
                services.AddHostedService<Worker>();
            });
}
