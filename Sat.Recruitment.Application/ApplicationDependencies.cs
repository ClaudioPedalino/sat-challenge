using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.Application.Commands;
using Sat.Recruitment.Application.Interfaces;
using Sat.Recruitment.Application.Mappers;
using Sat.Recruitment.Application.MediatorBehaviours;
using Sat.Recruitment.Application.Validators;
using Sat.Recruitment.Infra.Interfaces;
using Sat.Recruitment.Infra.Persistence.Repositories;
using Serilog;
using StackExchange.Profiling;
using System.Reflection;

namespace Sat.Recruitment.Application
{
    public static class ApplicationDependencies
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            services.AddMediatR(typeof(CreateUserCommand).GetTypeInfo().Assembly)
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>))
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(CacheBehaviour<,>));

            services.AddSingleton<ILogger>(_ =>
                new LoggerConfiguration().WriteTo.Console().CreateLogger());

            services.AddScoped<IPaginable, Paginable>();
            
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddAutoMapper(typeof(UserProfile));

            services.AddFluentValidation(fv =>
                fv.RegisterValidatorsFromAssemblyContaining<CreateUserCommandValidator>());

            services.AddMiniProfiler(options =>
            {
                options.RouteBasePath = "/profiler";
                options.ColorScheme = ColorScheme.Dark;
            }).AddEntityFramework();

            return services;
        }
    }
}
