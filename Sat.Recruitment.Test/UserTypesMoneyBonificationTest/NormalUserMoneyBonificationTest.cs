using Sat.Recruitment.Domain;
using Sat.Recruitment.Domain.UserMoneyCalculation;
using Xunit;

namespace Sat.Recruitment.Test.UserTypesMoneyBonificationTest
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class NormalUserMoneyBonificationTest
    {
        private readonly ICalculationUserMoneyBonification _sut;

        public NormalUserMoneyBonificationTest()
        {
            _sut = new NormalUserMoneyBonification();
        }


        [Theory]
        [InlineData(110, 123.2)]
        [InlineData(150, 168)]
        [InlineData(170.4, 190.848)]
        public void NormalUserBonification_ShouldIncrease12Percent_WhenMoneyUpperTo100(
            decimal given, decimal expected)
        {
            var bonificationCalculation = _sut.CalculateUserMoneyBonification(given);
            Assert.Equal(expected, bonificationCalculation);
        }

        [Theory]
        [InlineData(15, 16.2)]
        [InlineData(50.4, 54.432)]
        [InlineData(80.3, 86.724)]
        public void NormalUserBonification_ShouldIncrease8Percent_WhenMoneyExclusiveBetween10And100(
            decimal given, decimal expected)
        {
            var bonificationCalculation = _sut.CalculateUserMoneyBonification(given);
            Assert.Equal(expected, bonificationCalculation);
        }

        [Theory]
        [InlineData(3, 3)]
        [InlineData(10, 10)]
        public void NormalUserBonification_ShouldNotApplyAnyChange_WhenMoneyEqualOrLessThan10(
            decimal given, decimal expected)
        {
            var bonificationCalculation = _sut.CalculateUserMoneyBonification(given);
            Assert.Equal(expected, bonificationCalculation);
        }
    }
}
