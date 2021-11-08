using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Application.Commands;
using Sat.Recruitment.Application.Wrappers;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AuthenticationResult))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(AuthenticationResult))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse<string>))]
        public async Task<IActionResult> Login([FromBody] LoginAuthUserCommand command) =>
            await _mediator.AuthCommandWrapper(command);


        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AuthenticationResult))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(AuthenticationResult))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse<string>))]
        public async Task<IActionResult> Register([FromBody] RegisterAuthUserCommand command) =>
            await _mediator.AuthCommandWrapper(command);
    }
}
