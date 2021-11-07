using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Sat.Recruitment.Application.Interfaces;
using Sat.Recruitment.Application.Validators;
using Sat.Recruitment.Application.Wrappers;
using Sat.Recruitment.Domain.Entities;
using Sat.Recruitment.Infra.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Sat.Recruitment.Application.Commands
{
    public record LoginAuthUserCommand(string Email, string Password)
    : IRequest<AuthenticationResult>
    { }

    public class LoginAuthUserCommandHandler : IRequestHandler<LoginAuthUserCommand, AuthenticationResult>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AuthUser> _userManager;
        private readonly ITokenService _tokenService;

        public LoginAuthUserCommandHandler(IMapper mapper,
                                       UserManager<AuthUser> userManager,
                                       ITokenService tokenService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<AuthenticationResult> Handle(LoginAuthUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user is null)
                return UserValidation.ReturnUserException(Const.UserDoesNotExist);

            var userHasValidPassword = await _userManager.CheckPasswordAsync(user, request.Password);

            return !userHasValidPassword
                ? UserValidation.ReturnUserException(Const.UserOrPasswordAreIncorrect)
                : _tokenService.GenerateAuthResult(user);
        }
    }
}
