using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Application.Commands;
using Sat.Recruitment.Application.Queries;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<ActionResult> GetAllUser([FromQuery] GetAllUserQuery request)
        {
            var response = await _mediator.Send(request);
            return !response.Data.Any()
               ? NoContent()
               : Ok(response);
        }

        [HttpGet]
        [Route("get-by-id/{userId}")]
        public async Task<ActionResult> GetAllUser([FromRoute] Guid userId)
        {
            var response = await _mediator.Send(new GetUserByIdQuery(userId));

            return response is null
                ? NoContent()
                : Ok(response);
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> CreateUser([FromBody] CreateUserCommand request)
        {
            var response = await _mediator.Send(request);

            return response.IsSuccess
                ? Ok(response)
                : BadRequest(response);
        }
    }
}
