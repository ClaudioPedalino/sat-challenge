namespace Sat.Recruitment.Domain.UserMoneyCalculation
{

    public class PremiumUserMoneyBonification : ICalculationUserMoneyBonification
    {
        public decimal CalculateUserMoneyBonification(decimal money)
        {
            decimal result = money;
            if (money > 100)
                result += money * UserTypePercentage.Premium;

            return result;
        }
    }
}
