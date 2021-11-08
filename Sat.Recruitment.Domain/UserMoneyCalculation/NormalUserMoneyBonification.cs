namespace Sat.Recruitment.Domain.UserMoneyCalculation
{
    public class NormalUserMoneyBonification : ICalculationUserMoneyBonification
    {
        public decimal CalculateUserMoneyBonification(decimal money)
        {
            decimal result = money;
            if (money > 100)
            {
                result += money * UserTypePercentage.NormalMoreThan100;
            }
            else if (money is > 10 and < 100)
            {
                result += money * UserTypePercentage.NormalBetween10And100;
            }

            return result;
        }
    }
}
