using AutoMapper;
using MediatR;
using Sat.Recruitment.Application.Helpers;
using Sat.Recruitment.Application.Interfaces;
using Sat.Recruitment.Application.Wrappers;
using Sat.Recruitment.Domain;
using Sat.Recruitment.Domain.Entities;
using Sat.Recruitment.Domain.Enums;
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
            var newUser = _mapper.Map<User>(new Tuple<CreateUserCommand, string>(
                request,
                request.Email.NormalizeEmail()));

            var alreadyExist = await _userRepository.AlreadyExist(newUser);
            if (alreadyExist)
                CommandResponse.Fail("User is duplicated");

            CalculateUserMoney(request.Money, newUser);

            await _userRepository.Insert(newUser);

            return CommandResponse.SuccesfullyCreated<User>($"{newUser.Name} with usertype {newUser.UserType}");
        }


        private static void CalculateUserMoney(decimal requestMoney, User newUser)
        {
            switch (newUser.UserType)
            {
                case nameof(Domain.Enums.UserType.Normal):
                    if (requestMoney > 100)
                    {
                        newUser.Money += requestMoney * UserTypePercentage.NormalMoreThan100;
                    }
                    if (requestMoney is > 10 and < 100)
                    {
                        newUser.Money += requestMoney * UserTypePercentage.NormalBetween10And100;
                    }
                    break;
                case nameof(Domain.Enums.UserType.SuperUser):
                    if (requestMoney > 100)
                    {
                        newUser.Money += requestMoney * UserTypePercentage.SuperUser;
                    }
                    break;
                case nameof(Domain.Enums.UserType.Premium):
                    if (requestMoney > 100)
                    {
                        newUser.Money += requestMoney * UserTypePercentage.Premium;
                    }
                    break;
            }

            //if (newUser.IsNormalUser())
            //{
            //    if (requestMoney > 100)
            //    {
            //        newUser.Money += requestMoney * UserTypePercentage.NormalMoreThan100;
            //    }
            //    if (requestMoney is > 10 and < 100)
            //    {
            //        newUser.Money += requestMoney * UserTypePercentage.NormalBetween10And100;
            //    }
            //}
            //if (newUser.IsSuperUser())
            //{
            //    if (requestMoney > 100)
            //    {
            //        newUser.Money += requestMoney * UserTypePercentage.SuperUser;
            //    }
            //}
            //if (newUser.IsPremiumUser())
            //{
            //    if (requestMoney > 100)
            //    {
            //        newUser.Money += requestMoney * UserTypePercentage.Premium;
            //    }
            //}
        }
    }
}
