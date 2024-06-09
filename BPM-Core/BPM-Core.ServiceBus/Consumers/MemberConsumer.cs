using BPM_Core.BLL.Models;
using BPM_Core.BLL.Services;
using BPM_Core.ServiceBus.Models;
using BPM_Core.ServiceBus.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace BPM_Core.ServiceBus.Consumers
{
    public class MemberConsumer : BaseConsumer
    {
        private readonly IConfiguration _configuration;
        private readonly IConsumerService _consumerService;

        public MemberConsumer(
            IConfiguration configuration, 
            IConsumerService consumerService)
        {
            _configuration = configuration;
            _consumerService = consumerService;

            var hostname = _configuration["RabbitMQ:HostName"];
            var queueName = _configuration["RabbitMQ:RegisterMemberToBpmCoreQueue"];
            Initialize(hostname, queueName);
        }

        protected override void OnMessageReceived(object model, BasicDeliverEventArgs ea)
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            var memberModel = System.Text.Json.JsonSerializer.Deserialize<RegisterMemberModel>(message);
            _consumerService.RegisterMember(memberModel);
        }
    }
}
