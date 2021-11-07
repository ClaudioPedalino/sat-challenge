using MediatR;
using Sat.Recruitment.Application.Interfaces;
using Sat.Recruitment.Application.Wrappers;
using Sat.Recruitment.Domain.Entities;
using Sat.Recruitment.Infra.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sat.Recruitment.Application.Commands
{
    public record DeleteUserCommand(Guid Id) : IRequest<CommandResponse>, ITransactionable { }

    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, CommandResponse>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<CommandResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            => await _userRepository.Delete(request.Id)
            ? CommandResponse.SuccesfullyDeleted<User>()
            : CommandResponse.NotFound();
    }
}
