using GroupApp.Delivery.Domain.Entities;
using GroupApp.Delivery.Domain.Interfaces.Services;

namespace GroupAdd.Delivery.Consumer.Services;

public class NotifierService : INotifierService
{
    public void Notify(Order order)
    {
        SendEmail(order.Customer.Email);
    }

    private static void SendEmail(string email)
    {
        Console.WriteLine("Email sent to recipient: " + email);
    }
}
