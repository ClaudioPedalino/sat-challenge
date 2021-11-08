using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Sat.Recruitment.Application.Interfaces;
using Sat.Recruitment.Application.Validators;
using Sat.Recruitment.Application.Wrappers;
using Sat.Recruitment.Domain.Entities;
using Sat.Recruitment.Infra.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sat.Recruitment.Application.Commands
{
    public record RegisterAuthUserCommand(string Email, string Password)
        : IRequest<AuthenticationResult>, ITransactionable
    { }

    public class RegisterAuthUserCommandHandler : IRequestHandler<RegisterAuthUserCommand, AuthenticationResult>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AuthUser> _userManager;
        private readonly ITokenService _tokenService;

        public RegisterAuthUserCommandHandler(IMapper mapper,
                                              UserManager<AuthUser> userManager,
                                              ITokenService tokenService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<AuthenticationResult> Handle(RegisterAuthUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userManager.FindByEmailAsync(request.Email);
            if (existingUser is not null)
                return UserValidation.ReturnUserException(Const.UserAlreadyExist);

            var newUser = _mapper.Map<AuthUser>(request);

            var createdUser = await _userManager.CreateAsync(newUser, request.Password);

            return !createdUser.Succeeded
                ? new AuthenticationResult(string.Empty, createdUser.Errors.Select(x => x.Description))
                : _tokenService.GenerateAuthResult(newUser);
        }
    }
}
