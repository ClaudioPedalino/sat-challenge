using Sat.Recruitment.Domain;
using Sat.Recruitment.Domain.UserMoneyCalculation;
using Xunit;

namespace Sat.Recruitment.Test.UserTypesMoneyBonificationTest
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class SuperUserMoneyBonificationTest
    {
        private readonly ICalculationUserMoneyBonification _sut;
        public SuperUserMoneyBonificationTest()
        {
            _sut = new SuperUserMoneyBonification();
        }

        [Theory]
        [InlineData(110, 132)]
        [InlineData(150, 180)]
        [InlineData(170.4, 204.48)]
        public void SuperUserBonification_ShouldIncrease20Percent_WhenMoneyUpperTo100(
            decimal given, decimal expected)
        {
            var bonificationCalculation = _sut.CalculateUserMoneyBonification(given);
            Assert.Equal(expected, bonificationCalculation);
        }


        [Theory]
        [InlineData(10, 10)]
        [InlineData(50.4, 50.4)]
        [InlineData(100, 100)]
        public void SuperUserBonification_ShouldNotApplyAnyChange_WhenMoneyEqualOrLessThan100(
            decimal given, decimal expected)
        {
            var bonificationCalculation = _sut.CalculateUserMoneyBonification(given);
            Assert.Equal(expected, bonificationCalculation);
        }
    }
}
