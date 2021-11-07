using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Api.CustomAttributes;
using Sat.Recruitment.Application.Commands;
using Sat.Recruitment.Application.Dto;
using Sat.Recruitment.Application.Models;
using Sat.Recruitment.Application.Queries;
using Sat.Recruitment.Application.Wrappers;
using System;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
        public async Task<IActionResult> GetAllUser([FromQuery] GetAllUserDto request) =>
            await _mediator.PaginatedQueryWrapper<GetAllUserQuery, GetUserResponse>(
                GetAllUserQuery.BuildGetAllUserQuery(request));


        [HttpGet]
        [ApiKey]
        [Route("get-by-id/{userId}")]
        public async Task<IActionResult> GetAllUser([FromRoute] Guid userId, [FromQuery] bool bypassCache)
            => await _mediator.QuerySingleWrapper<GetUserByIdQuery, GetUserDetailResponse>(
                new GetUserByIdQuery(userId, bypassCache));


        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("create")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand request) =>
            await _mediator.CommandWrapper(request);


        [HttpDelete]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("delete/{userId}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid userId) =>
            await _mediator.CommandWrapper(new DeleteUserCommand(userId));
    }
}
