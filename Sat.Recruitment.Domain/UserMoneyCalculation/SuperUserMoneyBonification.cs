namespace Sat.Recruitment.Domain.UserMoneyCalculation
{
    public class SuperUserMoneyBonification : ICalculationUserMoneyBonification
    {
        public decimal CalculateUserMoneyBonification(decimal money)
        {
            decimal result = money;
            if (money > 100)
                result += money * UserTypePercentage.SuperUser;

            return result;
        }
    }
}
