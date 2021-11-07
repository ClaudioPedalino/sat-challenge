using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.Infra.AppConfiguration;
using System;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.CustomAttributes
{
    /// http://codingsonata.com/secure-asp-net-core-web-api-using-api-key-authentication/
    [AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiKeyAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var appSettings = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            
            var apiKey = appSettings.GetValue<string>(
                $"{nameof(AppConfig)}:{nameof(AppConfig.Api)}:{nameof(AppConfig.Api.SatApiKey)}");

            if (!context.HttpContext.Request.Headers.TryGetValue(nameof(AppConfig.Api.SatApiKey), out var extractedApiKey))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "Api Key was not provided"
                };
                return;
            }
            
            if (!apiKey.Equals(extractedApiKey))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "Api Key is not valid"
                };
                return;
            }

            await next();
        }
    }
}
