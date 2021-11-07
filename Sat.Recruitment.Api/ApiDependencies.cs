using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Sat.Recruitment.Application.Interfaces;
using Sat.Recruitment.Application.Services;
using Sat.Recruitment.Domain.Entities;
using Sat.Recruitment.Infra.AppConfiguration;
using Sat.Recruitment.Infra.Persistence;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Sat.Recruitment.Api
{
    public static class ApiDependencies
    {
        public static AppConfig AddAppConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var appConfig = new AppConfig();
            services.Configure<DatabaseConfig>(configuration.GetSection($"{nameof(AppConfig)}:{nameof(AppConfig.DatabaseConfig)}"));
            services.Configure<CacheSetting>(configuration.GetSection($"{nameof(AppConfig)}:{nameof(AppConfig.CacheSetting)}"));
            services.Configure<IpRateLimitOptions>(configuration.GetSection($"{nameof(AppConfig)}:{nameof(AppConfig.IpRateLimit)}"));
            services.Configure<JwtSettings>(configuration.GetSection($"{nameof(AppConfig)}:{nameof(AppConfig.JwtSettings)}"));

            configuration.Bind(nameof(AppConfig), appConfig);
            return appConfig;
        }

        public static IServiceCollection AddApiConfiguration(this IServiceCollection services, AppConfig appConfig)
        {
            services.AddOptions();
            services.AddMemoryCache();
            services.AddIdentityAuth(appConfig);
            services.AddRateLimit();
            services.AddSwagger(appConfig);

            return services;
        }


        private static void AddIdentityAuth(this IServiceCollection services, AppConfig appConfig)
        {
            services
                .AddDefaultIdentity<AuthUser>()
                .AddEntityFrameworkStores<DataContext>();

            services
                .AddAuthentication(config =>
                {
                    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    config.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(config =>
                {
                    config.SaveToken = true;
                    config.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(appConfig.JwtSettings.Secret)),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        RequireExpirationTime = false,
                        ValidateLifetime = true
                    };
                });

            services.AddScoped<ITokenService, TokenService>();
        }

        private static void AddRateLimit(this IServiceCollection services)
        {
            services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();
            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
        }

        private static void AddSwagger(this IServiceCollection services, AppConfig appConfig)
        {
            services
                .AddSwaggerGen(c =>
                {
                    c.SwaggerDoc(appConfig.Api.Version, new OpenApiInfo { Title = appConfig.Api.Name, Version = appConfig.Api.Version });
                    c.EnableAnnotations();
                    c.IgnoreObsoleteActions();
                    c.IgnoreObsoleteProperties();
                    c.OrderActionsBy((apiDesc) => $"{apiDesc.ActionDescriptor.RouteValues["controller"]}_{apiDesc.ActionDescriptor}");
                    c.CustomSchemaIds((type) => type.FullName);
                    c.CustomOperationIds(apiDesc =>
                    {
                        return apiDesc.TryGetMethodInfo(out MethodInfo methodInfo) ? methodInfo.Name : null;
                    });

                    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        Description = "JWT Authorization header using the bearer scheme",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = appConfig.JwtSettings.TokenType
                    });
                    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                        {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = appConfig.JwtSettings.TokenType
                        },
                        Scheme = "oauth2",
                        Name = appConfig.JwtSettings.TokenType,
                        In = ParameterLocation.Header,
                    },
                    new List<string>()
                }
                        });
                });
        }

        public static IApplicationBuilder AddSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger(c =>
            {
                c.PreSerializeFilters.Add((swagger, httpReq) =>
                {
                    swagger.Servers = new List<OpenApiServer> { new OpenApiServer { Url = $"{httpReq.Scheme}://{httpReq.Host.Value}" } };
                });
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ppepe");
                c.DefaultModelExpandDepth(2);
                c.DefaultModelRendering(ModelRendering.Example);
                c.DefaultModelsExpandDepth(-1);
                c.DisplayOperationId();
                c.DisplayRequestDuration();
                c.EnableDeepLinking();
                c.EnableFilter();
                c.MaxDisplayedTags(5);
                c.ShowExtensions();
                c.ShowCommonExtensions();
            });

            return app;
        }

    }
}
