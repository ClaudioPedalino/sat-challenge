using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Application.Commands;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromServices] IMediator _mediator, LoginAuthUserCommand command)
        {
            var response = await _mediator.Send(command);
            return response.ErrorMessages is null
                ? BadRequest(response)
                : Ok(value: response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromServices] IMediator _mediator, RegisterAuthUserCommand command)
        {
            var response = await _mediator.Send(command);
            return response.ErrorMessages is null
                ? BadRequest(response)
                : Ok(value: response);
        }
    }
}
