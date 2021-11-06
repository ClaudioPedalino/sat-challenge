using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.Application.Interfaces;
using Sat.Recruitment.Application.Mappers;
using Sat.Recruitment.Application.Validators;
using Sat.Recruitment.Infra.Interfaces;
using Sat.Recruitment.Infra.Persistence.Repositories;

namespace Sat.Recruitment.Application
{
    public static class ApplicationDependencies
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IPaginable, Paginable>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddAutoMapper(typeof(UserProfile));

            services.AddFluentValidation(fv =>
                fv.RegisterValidatorsFromAssemblyContaining<CreateUserCommandValidator>());

            return services;
        }
    }
}
