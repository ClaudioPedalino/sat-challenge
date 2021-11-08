namespace Sat.Recruitment.Domain.UserMoneyCalculation
{
    public static class UserTypePercentage
    {
        //TODO: llevar a appsettings por si queremos hacer estos valores dinámicos
        public static decimal NormalMoreThan100 { get; set; } = 0.12M; 
        public static decimal NormalBetween10And100 { get; set; } = 0.08M;
        public static decimal SuperUser { get; set; } = 0.20M;
        public static decimal Premium { get; set; } = 2;
    }
}