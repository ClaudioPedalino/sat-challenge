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
    public class CreateUserCommand : IRequest<CommandResult>, ITransactionable
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public UserType UserType { get; set; }
        public decimal Money { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CommandResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<CommandResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var newUser = _mapper.Map<User>(new Tuple<CreateUserCommand, string>(
                request,
                request.Email.NormalizeEmail()));

            var alreadyExist = await _userRepository.AlreadyExist(newUser);
            if (alreadyExist)
                CommandResult.Fail("User is duplicated");
            
            CalculateUserMoney(request.Money, newUser);

            await _userRepository.Insert(newUser);
            return CommandResult.Success("User Created");
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
