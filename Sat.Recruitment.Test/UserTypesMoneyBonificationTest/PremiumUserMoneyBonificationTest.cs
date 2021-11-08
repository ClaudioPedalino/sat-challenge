using Sat.Recruitment.Domain;
using Sat.Recruitment.Domain.UserMoneyCalculation;
using Xunit;

namespace Sat.Recruitment.Test.UserTypesMoneyBonificationTest
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class PremiumUserMoneyBonificationTest
    {
        private readonly ICalculationUserMoneyBonification _sut;
        public PremiumUserMoneyBonificationTest()
        {
            _sut = new PremiumUserMoneyBonification();
        }

        [Theory]
        [InlineData(110, 330)]
        [InlineData(150, 450)]
        [InlineData(170.4, 511.2)]
        public void PremiumUserBonification_ShouldIncrease300Percent_WhenMoneyUpperTo100(
            decimal given, decimal expected)
        {
            var bonificationCalculation = _sut.CalculateUserMoneyBonification(given);
            Assert.Equal(expected, bonificationCalculation);
        }

        [Theory]
        [InlineData(10, 10)]
        [InlineData(50.4, 50.4)]
        [InlineData(100, 100)]
        public void PremiumUserBonification_ShouldNotApplyAnyChange_WhenMoneyEqualOrLessThan100(
            decimal given, decimal expected)
        {
            var bonificationCalculation = _sut.CalculateUserMoneyBonification(given);
            Assert.Equal(expected, bonificationCalculation);
        }
    }
}
