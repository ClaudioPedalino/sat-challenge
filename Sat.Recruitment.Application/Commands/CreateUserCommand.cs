using AutoMapper;
using MediatR;
using Sat.Recruitment.Application.Helpers;
using Sat.Recruitment.Application.Interfaces;
using Sat.Recruitment.Application.Wrappers;
using Sat.Recruitment.Domain;
using Sat.Recruitment.Domain.Entities;
using Sat.Recruitment.Domain.Enums;
using Sat.Recruitment.Domain.UserMoneyCalculation;
using Sat.Recruitment.Infra.Common;
using Sat.Recruitment.Infra.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sat.Recruitment.Application.Commands
{
    public record CreateUserCommand(
        string Name,
        string Email,
        string Address,
        string Phone,
        UserType UserType,
        decimal Money
        )
        : IRequest<CommandResponse>, ITransactionable
    { }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CommandResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<CommandResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<User>(new Tuple<CreateUserCommand, string, decimal>(
                request,
                request.Email.NormalizeEmail(),
                ApplyMoneyBonification(request.UserType, request.Money)));

            var alreadyExist = await _userRepository.AlreadyExist(entity);
            if (alreadyExist)
                return CommandResponse.Fail(Const.UserDuplicated);

            await _userRepository.Insert(entity);

            return CommandResponse.SuccesfullyCreated<User>($"{entity.Name} with usertype {entity.UserType}");
        }

        private static decimal ApplyMoneyBonification(UserType userType, decimal money)
            => userType switch
            {
                UserType.Normal => new NormalUserMoneyBonification().CalculateUserMoneyBonification(money),
                UserType.SuperUser => new SuperUserMoneyBonification().CalculateUserMoneyBonification(money),
                UserType.Premium => new PremiumUserMoneyBonification().CalculateUserMoneyBonification(money),
                _ => money,
            };
    }
}
