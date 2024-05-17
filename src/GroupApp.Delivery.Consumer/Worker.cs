#nullable disable

using Confluent.Kafka;
using GroupApp.Delivery.Consumer.Services;
using GroupApp.Delivery.Domain.Entities;
using GroupApp.Delivery.Domain.Interfaces.Services;
using GroupApp.Delivery.Infrastructure.Kafka.Settings;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace GroupApp.Delivery.Consumer;

public class Worker : IHostedService
{
    private readonly ILogger<Worker> _logger;
    private readonly OrderSettings _orderSettings;

    public Worker(ILogger<Worker> logger, IOptions<OrderSettings> orderSettings)
    {
        _logger = logger;
        _orderSettings = orderSettings.Value;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Worker Service running");

        await ExecuteAsync(cancellationToken).ConfigureAwait(false);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    private async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var kafkaBootstrapServers = _orderSettings.KafkaBootstrapServer;
        var notifierConsumeGroupName = _orderSettings.NotifierConsumeGroupName;
        var orderTopicName = _orderSettings.OrderTopicName;

        INotifierService notifierService = new NotifierService();

        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Order notifier running at: {time}", DateTimeOffset.Now);

            var config = new ConsumerConfig
            {
                BootstrapServers = kafkaBootstrapServers,
                GroupId = notifierConsumeGroupName,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();

            consumer.Subscribe(orderTopicName);

            var cts = new CancellationTokenSource();

            Console.CancelKeyPress += (_, e) =>
            {
                e.Cancel = true;
                cts.Cancel();
            };

            try
            {
                while (true)
                {
                    try
                    {
                        var consumeResult = consumer.Consume(cts.Token);

                        Order order = JsonSerializer.Deserialize<Order>(consumeResult.Message.Value);

                        notifierService.Notify(order);

                        Console.WriteLine($"Mensagem recebida: {consumeResult.Message.Value}");
                    }
                    catch (ConsumeException e)
                    {
                        Console.WriteLine($"Erro ao consumir a mensagem: {e.Error.Reason}");
                    }
                }
            }
            catch (OperationCanceledException)
            {
                consumer.Close();
            }
        }

        await Task.CompletedTask;
    }
}
