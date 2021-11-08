using FluentValidation;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Sat.Recruitment.Application.Wrappers;
using Sat.Recruitment.Domain.Exceptions;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = ApiResponse<string>.Fail(error.Message);
                responseModel.HasErrors = true;
                response.StatusCode = error switch
                {
                    CustomException => (int)HttpStatusCode.BadRequest,
                    ValidationException => (int)HttpStatusCode.BadRequest,
                    _ => (int)HttpStatusCode.InternalServerError,
                };

                var result = JsonConvert.SerializeObject(responseModel);
                await response.WriteAsync(result);
            }
        }
    }
}
