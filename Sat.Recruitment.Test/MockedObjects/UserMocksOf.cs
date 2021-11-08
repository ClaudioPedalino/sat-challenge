using Sat.Recruitment.Domain.Entities;

namespace Sat.Recruitment.Test.MockedObjects
{
    public static class UserMocksOf
    {
        public static User Valid_User()
            => new()
            {
                Name = "Mike",
                Email = "mike@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = "Normal",
                Money = 124
            };
    }
}
