using FluentValidation.AspNetCore;
using HealthChecks.UI.Client;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Sat.Recruitment.Application.Commands;
using Sat.Recruitment.Application.Interfaces;
using Sat.Recruitment.Application.Mappers;
using Sat.Recruitment.Application.MediatorBehaviours;
using Sat.Recruitment.Application.Queries;
using Sat.Recruitment.Application.Services;
using Sat.Recruitment.Application.Validators;
using Sat.Recruitment.Infra;
using Sat.Recruitment.Infra.AppConfiguration;
using Sat.Recruitment.Infra.Interfaces;
using Sat.Recruitment.Infra.Persistence.Repositories;
using Serilog;
using StackExchange.Profiling;
using System.Reflection;

namespace Sat.Recruitment.Application
{
    public static class ApplicationDependencies
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, AppConfig appConfig)
        {
            services.AddHttpContextAccessor();

            services.AddMediatR(typeof(CreateUserCommand).GetTypeInfo().Assembly)
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>))
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(CacheBehaviour<,>));

            services.AddSingleton<ILogger>(_ =>
                new LoggerConfiguration().WriteTo.Console().CreateLogger());

            services.AddScoped<IPaginableQuery, PaginableQuery>();

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<INotifierService, NotifierService>();

            services.AddAutoMapper(typeof(UserProfile));

            services.AddFluentValidation(fv =>
                fv.RegisterValidatorsFromAssemblyContaining<CreateUserCommandValidator>());

            services.AddMiniProfiler(options =>
            {
                options.RouteBasePath = "/profiler";
                options.ColorScheme = ColorScheme.Dark;
            }).AddEntityFramework();

            services.AddHealthCheck(appConfig);

            services.AddInfraestructure(appConfig);

            return services;
        }

        private static IServiceCollection AddHealthCheck(this IServiceCollection services, AppConfig appConfig)
        {
            services
                .AddHealthChecks()
                .AddCheck("Mock Service 1", () => HealthCheckResult.Healthy("Service 1 ok"))
                .AddSqlServer(
                    connectionString: appConfig.DatabaseConfig.SatDb,
                    healthQuery: "SELECT 1;",
                    name: "SQLServerDb-check",
                    failureStatus: HealthStatus.Degraded,
                    tags: new string[] { "Net6ApiDb" });

            services
                .AddHealthChecksUI()
                .AddSqlServerStorage(appConfig.DatabaseConfig.SatDb);

            return services;
        }


        public static IApplicationBuilder UseHealthCheck(this IApplicationBuilder app)
        {
            app.UseEndpoints(config =>
            {
                config.MapHealthChecksUI();

                config.MapHealthChecks("/health", new HealthCheckOptions
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
            });

            return app;
        }
    }
}
