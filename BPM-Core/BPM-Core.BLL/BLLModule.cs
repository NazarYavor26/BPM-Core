using BPM_Core.DAL;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BPM_Core.BLL
{
    public class BLLModule
    {
        public static void Load(IServiceCollection services, IConfiguration configuration)
        {
            DALModule.Load(services, configuration);
        }
    }
}
