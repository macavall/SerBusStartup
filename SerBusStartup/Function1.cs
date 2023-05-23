using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace SerBusStartup
{
    public class Function1
    {
        private readonly ServiceBusClient _serviceBusClient;

        public Function1(ServiceBusClient serviceBusClient)
        {
            _serviceBusClient = serviceBusClient;
        }

        [FunctionName("Function1")]
        public async Task Run([ServiceBusTrigger("myinputqueue", Connection = "sbconnstring", IsSessionsEnabled = false)] string[] myQueueItem, ILogger log)
        {
            string queueName = "queue";
            int maxMessageCount = 1000;

            // Create ServiceBusReceiverOptions object

            var serbusOptions = new ServiceBusReceiverOptions()
            {
                PrefetchCount = maxMessageCount
            };

            await using (ServiceBusReceiver receiver = _serviceBusClient.CreateReceiver(queueName, serbusOptions))
            {
                var messages = await receiver.ReceiveMessagesAsync(maxMessageCount);

                foreach (var message in messages)
                {
                    string messageBody = message.ToString();
                    log.LogInformation($"Received message: {messageBody}");

                    // Process the message as needed...

                    // Complete the message to remove it from the queue
                    await receiver.CompleteMessageAsync(message);
                }
            }
        }
    }
}