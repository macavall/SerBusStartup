using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using System;

namespace SerBusStartup
{
    public class SbService : ISbService
    {
        private readonly ILogger logger;
        public List<string> SbMessages = new List<string>();

        public SbService(ILogger<SbService> _logger) 
        {
            logger = _logger;
            logger.LogInformation("Starting SbService!!!!!!!!!!!!!!!");
        }       
        
        public void AddMessages(string msgInput)
        {
            SbMessages.Add(msgInput);
        }

        public int GetMessages()
        {
            return SbMessages.Count;
        }
    }
}