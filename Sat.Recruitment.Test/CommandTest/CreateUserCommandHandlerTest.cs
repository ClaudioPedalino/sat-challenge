using AutoMapper;
using Moq;
using Sat.Recruitment.Application.Commands;
using Sat.Recruitment.Application.Helpers;
using Sat.Recruitment.Domain.Entities;
using Sat.Recruitment.Infra.Interfaces;
using Sat.Recruitment.Test.MockedObjects;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Sat.Recruitment.Test.CommandTest
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class CreateUserCommandHandlerTest
    {
        private readonly CreateUserCommandHandler _sut;
        private readonly Mock<IUserRepository> _userRepositoryMock = new Mock<IUserRepository>();
        private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();

        public CreateUserCommandHandlerTest()
        {
            _sut = new CreateUserCommandHandler(_userRepositoryMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task CreateUser_ShouldCreateUser_WhenAllParamsGood()
        {
            var validCreateCommand = CommandMocksOf.Valid_CreateUserCommand();
            var validUser = UserMocksOf.Valid_User();

            _mapperMock.Setup(x => x.Map<User>(new Tuple<CreateUserCommand, string>(
                validCreateCommand,
                validCreateCommand.Email.NormalizeEmail())))
                .Returns(validUser);

            _userRepositoryMock.Setup(x => x.AlreadyExist(validUser))
                .ReturnsAsync(false);

            _userRepositoryMock.Setup(x => x.Insert(validUser));

            var response = await _sut.Handle(validCreateCommand, new CancellationToken());

            Assert.True(response.IsSuccess);
            Assert.Equal("User Mike with usertype Normal succesfully created", response.Message);
        }

        [Fact]
        public async Task CreateUser_ShouldFail_WhenTryToInsertDuplicated()
        {
            var validCreateCommand = CommandMocksOf.Valid_CreateUserCommand();
            var validUser = UserMocksOf.Valid_User();

            _mapperMock.Setup(x => x.Map<User>(new Tuple<CreateUserCommand, string>(
                validCreateCommand,
                validCreateCommand.Email.NormalizeEmail())))
                .Returns(validUser);

            _userRepositoryMock.Setup(x => x.AlreadyExist(validUser))
                .ReturnsAsync(true);

            var response = await _sut.Handle(validCreateCommand, new CancellationToken());

            Assert.False(response.IsSuccess);
            Assert.Equal("User is duplicated", response.Message);
        }

        [Fact]
        public async Task CreateUser_ShouldCallMethodAlreadyExist_WhenTryingToCreateUser()
        {
            var validCreateCommand = CommandMocksOf.Valid_CreateUserCommand();
            var validUser = UserMocksOf.Valid_User();

            _mapperMock.Setup(x => x.Map<User>(new Tuple<CreateUserCommand, string>(
                validCreateCommand,
                validCreateCommand.Email.NormalizeEmail())))
                .Returns(validUser);

            var response = await _sut.Handle(validCreateCommand, new CancellationToken());

            _userRepositoryMock.Verify(x => x.AlreadyExist(It.IsAny<User>()), times: Times.Once);
        }

        [Fact]
        public async Task CreateUser_ShouldCallMethodInsert_WhenTryingToCreateValidUser()
        {
            var validCreateCommand = CommandMocksOf.Valid_CreateUserCommand();
            var validUser = UserMocksOf.Valid_User();

            _mapperMock.Setup(x => x.Map<User>(new Tuple<CreateUserCommand, string>(
                validCreateCommand,
                validCreateCommand.Email.NormalizeEmail())))
                .Returns(validUser);

            _userRepositoryMock.Setup(x => x.AlreadyExist(validUser))
                .ReturnsAsync(false);

            var response = await _sut.Handle(validCreateCommand, new CancellationToken());

            _userRepositoryMock.Verify(x => x.Insert(It.IsAny<User>()), times: Times.Once);
        }
    }
}
