using BPM_Core.BLL;
using BPM_Core.DAL;
using BPM_Core.ServiceBus;

namespace BPM_Core.API.ServiceInitialization
{
    public static class ServiceInitializer
    {
        public static void InitializeServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.InitializeBLL(configuration);
            services.InitializeDAL(configuration);
            services.InitializeServiceBus(configuration);
        }
    }
}
