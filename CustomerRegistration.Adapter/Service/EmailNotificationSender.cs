using CustomerRegistration.Core.IService;
using Microsoft.Extensions.Options;

namespace CustomerRegistration.Adapter.Service
{
    public class EmailNotificationSender : INotificationSender
    {
        public EmailNotificationSender()
        {

        }

        public async Task Notify(string email)
        {
            Console.WriteLine($"Sending Email to: {email}");
        }
    }
}
