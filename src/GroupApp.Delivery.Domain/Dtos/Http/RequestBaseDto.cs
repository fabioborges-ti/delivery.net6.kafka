using System.Text.Json.Serialization;

namespace GroupApp.Delivery.Domain.Dtos.Http;

public class RequestBaseDto
{
    [JsonIgnore]
    public bool HasError { get; set; } = false;

    [JsonIgnore]
    public string ErrorMessage { get; set; } = string.Empty;
}
