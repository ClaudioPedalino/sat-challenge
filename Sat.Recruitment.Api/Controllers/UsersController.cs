using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Api.CustomAttributes;
using Sat.Recruitment.Application.Commands;
using Sat.Recruitment.Application.Dto;
using Sat.Recruitment.Application.Models.Responses;
using Sat.Recruitment.Application.Queries;
using Sat.Recruitment.Application.Wrappers;
using System;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ApiKey]
        [Route("get-all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResponse<GetUserResponse>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse<string>))]
        public async Task<IActionResult> GetAllUser([FromQuery] GetAllUserDto request) =>
            await _mediator.PaginatedQueryWrapper<GetAllUserQuery, GetUserResponse>(
                GetAllUserQuery.BuildGetAllUserQuery(request));


        [HttpGet]
        [ApiKey]
        [Route("get-by-id/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetUserDetailResponse))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse<string>))]
        public async Task<IActionResult> GetAllUser([FromRoute] Guid userId, [FromQuery] bool bypassCache)
            => await _mediator.QuerySingleWrapper<GetUserByIdQuery, GetUserDetailResponse>(
                new GetUserByIdQuery(userId, bypassCache));


        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("create")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommandResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommandResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse<string>))]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand request) =>
            await _mediator.CommandWrapper(request);


        [HttpDelete]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("delete/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommandResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommandResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse<string>))]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid userId) =>
            await _mediator.CommandWrapper(new DeleteUserCommand(userId));
    }
}
