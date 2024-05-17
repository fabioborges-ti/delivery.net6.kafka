using Confluent.Kafka;
using GroupApp.Delivery.Domain.Entities;
using GroupApp.Delivery.Domain.Interfaces.Services;
using GroupApp.Delivery.Infrastructure.Kafka.Settings;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace GroupApp.Delivery.Infrastructure.Kafka.Services;

public class PublisherMessage : IPublisherMessage
{
    private readonly OrderSettings _orderSettings;

    public PublisherMessage(IOptions<OrderSettings> settings)
    {
        _orderSettings = settings.Value;
    }

    public async Task PublishMessageToTopic(Order order)
    {
        var orderTopicName = _orderSettings.OrderTopicName;
        var kafkaBootstrapServers = _orderSettings.KafkaBootstrapServer;

        var config = new ProducerConfig
        {
            BootstrapServers = kafkaBootstrapServers
        };

        string orderConvertedToJson = JsonSerializer.Serialize(order);

        using var producer = new ProducerBuilder<Null, string>(config).Build();

        var deliveryReport = await producer.ProduceAsync(orderTopicName, new Message<Null, string> { Value = orderConvertedToJson });
    }
}
