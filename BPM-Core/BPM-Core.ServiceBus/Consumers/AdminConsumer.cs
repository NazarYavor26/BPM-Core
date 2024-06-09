using BPM_Core.ServiceBus.Models;
using BPM_Core.ServiceBus.Services;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client.Events;
using System.Text;

namespace BPM_Core.ServiceBus.Consumers
{
    public class AdminConsumer : BaseConsumer
    {
        private readonly IConfiguration _configuration;
        private readonly IConsumerService _consumerService;

        public AdminConsumer(
            IConfiguration configuration,
            IConsumerService consumerService)
        {
            _configuration = configuration;
            _consumerService = consumerService;

            var hostname = _configuration["RabbitMQ:HostName"];
            var queueName = _configuration["RabbitMQ:RegisterAdminToBpmCoreQueue"];
            Initialize(hostname, queueName);
        }

        protected override void OnMessageReceived(object model, BasicDeliverEventArgs ea)
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            var adminModel = System.Text.Json.JsonSerializer.Deserialize<RegisterAdminModel>(message);
            _consumerService.RegisterAdmin(adminModel);
        }
    }
}
