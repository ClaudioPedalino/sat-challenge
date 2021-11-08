using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.Infra.AppConfiguration;
using Sat.Recruitment.Infra.Interfaces;
using Sat.Recruitment.Infra.Persistence;

namespace Sat.Recruitment.Infra
{
    public static class InfraestructureDependencies
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services, AppConfig config)
        {
            services.AddDistributedMemoryCache();

            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlServer(config.DatabaseConfig.SatDb);
                opt.EnableSensitiveDataLogging();
                opt.EnableDetailedErrors();
            });

            services.AddScoped<IDataContext>(sp => sp.GetRequiredService<DataContext>());

            return services;
        }
    }
}
