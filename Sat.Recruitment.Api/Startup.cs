using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sat.Recruitment.Application;
using Sat.Recruitment.Application.AppConfig;
using Sat.Recruitment.Application.Commands;
using Sat.Recruitment.Application.MediatorBehaviours;
using Sat.Recruitment.Infra;
using System.Reflection;

namespace Sat.Recruitment.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            var appConfig = new AppConfig();
            services.Configure<DatabaseConfig>(Configuration.GetSection($"{nameof(AppConfig)}:{nameof(AppConfig.DatabaseConfig)}"));
            Configuration.Bind(nameof(AppConfig), appConfig);

            services.AddMediatR(typeof(CreateUserCommand).GetTypeInfo().Assembly)
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>));
            
            services.AddHttpContextAccessor();

            services.AddApplication();
            services.AddInfraestructure(Configuration);

            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
