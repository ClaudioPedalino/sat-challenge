using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Application.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Sat.Recruitment.Application.Wrappers
{
    public static class ApiResponseWrapper
    {
        public static async Task<IActionResult> PaginatedQueryWrapper<TQuery, TResponse>(this IMediator _mediator, TQuery request)
            where TResponse : IQueryResponse
        {
            var response = await _mediator.Send(request) as PaginationResponse<TResponse>;

            return !response.Data.Any()
               ? new NoContentResult()
               : new OkObjectResult(response);
        }

        public static async Task<IActionResult> QuerySingleWrapper<TQuery, TResponse>(this IMediator _mediator, TQuery request)
            where TResponse : IQueryResponse
        {
            var response = (TResponse)await _mediator.Send(request);

            return response is null
                ? new NoContentResult()
                : new OkObjectResult(response);
        }

        public static async Task<IActionResult> CommandWrapper<TCommand>(this IMediator _mediator, TCommand command)
        {
            var response = await _mediator.Send(command) as CommandResponse;

            return !response.IsSuccess
                ? new BadRequestObjectResult(response)
                : new OkObjectResult(response);
        }
    }
}
