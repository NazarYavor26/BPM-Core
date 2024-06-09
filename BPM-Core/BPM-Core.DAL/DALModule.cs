using BPM_Core.DAL.DbContexts;
using BPM_Core.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BPM_Core.DAL
{
    public static class DALModule
    {
        public static void InitializeDAL(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(option => 
                option.UseSqlServer(configuration.GetConnectionString("DBConnection")), ServiceLifetime.Singleton);

            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddTransient<ITeamMembershipRepository, TeamMembershipRepository>();
            services.AddTransient<ITeamRepository, TeamRepository>();
        }
    }
}
