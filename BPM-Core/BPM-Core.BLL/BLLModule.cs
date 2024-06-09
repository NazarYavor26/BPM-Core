using BPM_Core.BLL.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BPM_Core.BLL
{
    public static class BLLModule
    {
        public static void InitializeBLL(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ITeamService, TeamService>();
            services.AddTransient<IUserService, UserService>();
            
        }
    }
}
