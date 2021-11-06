namespace Sat.Recruitment.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string UserType { get; set; }
        public decimal Money { get; set; }

        //public bool IsNormalUser() =>
        //    UserType == nameof(Enums.UserType.Normal);

        //public bool IsSuperUser() =>
        //    UserType == nameof(Enums.UserType.SuperUser);

        //public bool IsPremiumUser() =>
        //    UserType == nameof(Enums.UserType.Premium);

    }
}
