using Azure.Messaging.ServiceBus;

namespace SerBusStartup
{
    public class ServiceBusClientProvider : IServiceBusClientProvider
    {
        private readonly string connectionString;
        private readonly string queueName;

        public ServiceBusClientProvider(string connectionString, string queueName)
        {
            this.connectionString = "";
            this.queueName = "queue";
        }

        public string GetQueueName()
        {
            return this.queueName;
        }

        public ServiceBusClient GetServiceBusClient()
        {
            return new ServiceBusClient(connectionString);
        }
    }
}
