using Azure.Messaging.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerBusStartup
{
    public interface IServiceBusClientProvider
    {
        ServiceBusClient GetServiceBusClient();

        string GetQueueName();
    }
}
