using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(SerBusStartup.Startup))]

namespace SerBusStartup
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            ConfigureServices(builder.Services);

            builder.Services.AddSingleton<IServiceBusClientProvider, ServiceBusClientProvider>(); //( (s) => 
                //{
                //    return new SbService();
                //}); // <ISbService, SbService>();

            //throw new Exception("VERY BAD EXCEPTION BE AFRAID!!!");
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // Add the Service Bus client as a singleton
            services.AddSingleton(serviceProvider =>
            {
                string connectionString = "Endpoint=sb://serbus56hub.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=ivXACMMMswqTtfZfzD/wnnMneKnqUp/iR+ASbGTtfQc=";
                string queueName = "queue";

                // Create and return a new instance of the Service Bus client
                return new ServiceBusClient(connectionString);
            });
        }
    }
}
