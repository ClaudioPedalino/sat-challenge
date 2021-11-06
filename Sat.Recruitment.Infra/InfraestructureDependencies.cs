using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.Infra.Interfaces;
using Sat.Recruitment.Infra.Persistence;

namespace Sat.Recruitment.Infra
{
    public static class InfraestructureDependencies
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("SatDB"));
                opt.EnableSensitiveDataLogging();
                opt.EnableDetailedErrors();
            });

            services.AddScoped<IDataContext>(sp => sp.GetRequiredService<DataContext>());

            return services;
        }
    }
}
