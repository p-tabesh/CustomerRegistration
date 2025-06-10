using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRegistration.Core.IService
{
    public interface INotificationSender
    {
        Task Notify(string identification);
    }
}
