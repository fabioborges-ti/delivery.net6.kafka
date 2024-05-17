#nullable disable

namespace GroupApp.Delivery.Infrastructure.Kafka.Settings;

public class OrderSettings
{
    public string KafkaBootstrapServer { get; set; }
    public string OrderTopicName { get; set; }
    public string NotifierConsumeGroupName { get; set; }
}
