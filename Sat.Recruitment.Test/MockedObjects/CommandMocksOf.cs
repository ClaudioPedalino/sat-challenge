using Sat.Recruitment.Application.Commands;
using Sat.Recruitment.Domain.Enums;

namespace Sat.Recruitment.Test.MockedObjects
{
    public class CommandMocksOf
    {
        public static CreateUserCommand Valid_CreateUserCommand() =>
            new CreateUserCommand(
            Name: "Mike",
            Email: "mike@gmail.com",
            Address: "Av. Juan G",
            Phone: "+349 1122354215",
            UserType: UserType.Normal,
            Money: 5);

        public static CreateUserCommand Parametrizable(
            string name = "Pepe",
            string email = "Pepe@gmail.com",
            string address = "Calle Falsa 123",
            string phone = "11-1234-1234",
            UserType userType = UserType.Normal,
            decimal money = 123) =>
            new CreateUserCommand(
            Name: name,
            Email: email,
            Address: address,
            Phone: phone,
            UserType: userType,
            Money: money);
    }
}
