using CustomerRegistration.Core.IService;
using Microsoft.Extensions.Options;

namespace CustomerRegistration.Adapter.Service
{
    public class EmailNotificationSender : INotificationSender
    {
        public EmailNotificationSender(IOptions<EmailConfiguration> configuration)
        {

        }

        public async Task Notify(string identification)
        {
            throw new NotImplementedException();
        }
    }
}
