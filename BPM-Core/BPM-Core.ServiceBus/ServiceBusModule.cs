using BPM_Core.ServiceBus.Consumers;
using BPM_Core.ServiceBus.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BPM_Core.ServiceBus
{
    public static class ServiceBusModule
    {
        public static void InitializeServiceBus(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHostedService<AdminConsumer>();
            services.AddHostedService<MemberConsumer>();

            services.AddTransient<IConsumerService, ConsumerService>();
        }
    }
}
