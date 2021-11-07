using FluentValidation.TestHelper;
using Sat.Recruitment.Application.Validators;
using Sat.Recruitment.Domain.Enums;
using Sat.Recruitment.Test.MockedObjects;
using System.Threading.Tasks;
using Xunit;

namespace Sat.Recruitment.Test.ValidationTest
{
    public class CreateUserCommandValidatorTest
    {
        private readonly CreateUserCommandValidator _createUserCommandValidator;

        private const string LONG_TEXT = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been";
        private const string SHORT_TEXT = "a";

        public CreateUserCommandValidatorTest()
        {
            _createUserCommandValidator = new CreateUserCommandValidator();
        }

        [Fact]
        public async Task CreateUserValidator_ShouldPass_WhenValidCommand()
        {
            var validation = await _createUserCommandValidator.TestValidateAsync(
                CommandMocksOf.Valid_CreateUserCommand());
            validation.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public async Task CreateUserValidator_ShouldFail_WhenEmptyName()
        {
            var validation = await _createUserCommandValidator.TestValidateAsync(
                CommandMocksOf.Parametrizable(name: string.Empty));

            validation.ShouldHaveValidationErrorFor(u => u.Name)
                .WithErrorMessage("'Name' must not be empty.");
        }

        [Fact]
        public async Task CreateUserValidator_ShouldFail_WhenShortName()
        {
            var validation = await _createUserCommandValidator.TestValidateAsync(
                CommandMocksOf.Parametrizable(name: SHORT_TEXT));

            validation.ShouldHaveValidationErrorFor(u => u.Name)
                .WithErrorMessage("The length of 'Name' must be at least 2 characters. You entered 1 characters.");
        }

        [Fact]
        public async Task CreateUserValidator_ShouldFail_WhenLongName()
        {
            var validation = await _createUserCommandValidator.TestValidateAsync(
                CommandMocksOf.Parametrizable(name: LONG_TEXT));

            validation.ShouldHaveValidationErrorFor(u => u.Name)
                .WithErrorMessage("The length of 'Name' must be 35 characters or fewer. You entered 95 characters.");
        }

        [Fact]
        public async Task CreateUserValidator_ShouldFail_WhenEmptyEmail()
        {
            var validation = await _createUserCommandValidator.TestValidateAsync(
                CommandMocksOf.Parametrizable(email: string.Empty));

            validation.ShouldHaveValidationErrorFor(u => u.Email)
                .WithErrorMessage("'Email' must not be empty.");
        }

        [Fact]
        public async Task CreateUserValidator_ShouldFail_WhenInvalidEmailFormat()
        {
            var validation = await _createUserCommandValidator.TestValidateAsync(
                CommandMocksOf.Parametrizable(email: "cosmefulanito"));

            validation.ShouldHaveValidationErrorFor(u => u.Email)
                .WithErrorMessage("'Email' is not a valid email address.");
        }

        [Fact]
        public async Task CreateUserValidator_ShouldFail_WhenLongEmail()
        {
            var validation = await _createUserCommandValidator.TestValidateAsync(
                CommandMocksOf.Parametrizable(email: LONG_TEXT + "@gmail.com"));

            validation.ShouldHaveValidationErrorFor(u => u.Email)
                .WithErrorMessage("The length of 'Email' must be 70 characters or fewer. You entered 105 characters.");
        }

        [Fact]
        public async Task CreateUserValidator_ShouldFail_WhenEmptyAddress()
        {
            var validation = await _createUserCommandValidator.TestValidateAsync(
                CommandMocksOf.Parametrizable(address: string.Empty));

            validation.ShouldHaveValidationErrorFor(u => u.Address)
                .WithErrorMessage("'Address' must not be empty.");
        }

        [Fact]
        public async Task CreateUserValidator_ShouldFail_WhenShortAddress()
        {
            var validation = await _createUserCommandValidator.TestValidateAsync(
                CommandMocksOf.Parametrizable(address: SHORT_TEXT));

            validation.ShouldHaveValidationErrorFor(u => u.Address)
                .WithErrorMessage("The length of 'Address' must be at least 5 characters. You entered 1 characters.");
        }

        [Fact]
        public async Task CreateUserValidator_ShouldFail_WhenLongAddress()
        {
            var validation = await _createUserCommandValidator.TestValidateAsync(
                CommandMocksOf.Parametrizable(address: LONG_TEXT));

            validation.ShouldHaveValidationErrorFor(u => u.Address)
                .WithErrorMessage("The length of 'Address' must be 70 characters or fewer. You entered 95 characters.");
        }

        [Fact]
        public async Task CreateUserValidator_ShouldFail_WhenEmptyPhone()
        {
            var validation = await _createUserCommandValidator.TestValidateAsync(
                CommandMocksOf.Parametrizable(phone: string.Empty));

            validation.ShouldHaveValidationErrorFor(u => u.Phone)
                .WithErrorMessage("'Phone' must not be empty.");
        }

        [Fact]
        public async Task CreateUserValidator_ShouldFail_WhenShortPhone()
        {
            var validation = await _createUserCommandValidator.TestValidateAsync(
                CommandMocksOf.Parametrizable(phone: SHORT_TEXT));

            validation.ShouldHaveValidationErrorFor(u => u.Phone)
                .WithErrorMessage("The length of 'Phone' must be at least 6 characters. You entered 1 characters.");
        }

        [Fact]
        public async Task CreateUserValidator_ShouldFail_WhenLongPhone()
        {
            var validation = await _createUserCommandValidator.TestValidateAsync(
                CommandMocksOf.Parametrizable(phone: LONG_TEXT));

            validation.ShouldHaveValidationErrorFor(u => u.Phone)
                .WithErrorMessage("The length of 'Phone' must be 21 characters or fewer. You entered 95 characters.");
        }

        [Fact]
        public async Task CreateUserValidator_ShouldFail_WhenZeroMoney()
        {
            var validation = await _createUserCommandValidator.TestValidateAsync(
                CommandMocksOf.Parametrizable(money: 0));

            validation.ShouldHaveValidationErrorFor(u => u.Money)
                .WithErrorMessage("'Money' must be greater than '0'.");
        }

        [Fact]
        public async Task CreateUserValidator_ShouldFail_WhenEmptyUserType()
        {
            var validation = await _createUserCommandValidator.TestValidateAsync(
                CommandMocksOf.Parametrizable(userType: default));

            validation.ShouldHaveValidationErrorFor(u => u.UserType)
                .WithErrorMessage("'User Type' must not be empty.");
        }

        [Fact]
        public async Task CreateUserValidator_ShouldFail_WhenInvalidUserType()
        {
            var validation = await _createUserCommandValidator.TestValidateAsync(
                CommandMocksOf.Parametrizable(userType: (UserType)99));

            validation.ShouldHaveValidationErrorFor(u => u.UserType)
                .WithErrorMessage("The given UserType doesn´t match with any valid UserType");
        }
    }
}
