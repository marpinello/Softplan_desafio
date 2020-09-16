namespace ServiceTest
{
    using MainService.Contracts;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;

    public class CalcServiceTest : IClassFixture<TestSetup>
    {
        private readonly ServiceProvider _serviceProvider;
        private ICalc _calcService;

        public CalcServiceTest(TestSetup testSetup)
        {
            _serviceProvider = testSetup.ServiceProvider;
            _calcService = _serviceProvider.GetService<ICalc>();
        }

        [Fact]
        public void GetInterestRateShouldReturnDecimal()
        {
            var result = _calcService.GetInterestRate();
            Assert.IsType<decimal>(result);
        }

        [Fact]
        public void GetInterestRateShouldReturn001()
        {
            var result = _calcService.GetInterestRate();
            Assert.Equal(0.01M, result);
        }

        [Theory]
        [InlineData(100, 5, 105.10)]
        [InlineData(106, 5, 111.40)]
        public void CalculateFinalAmmountIsOk(decimal initialAmmount, int months, decimal expectedResult)
        {
            var actual = _calcService.CalculateFinalAmmount(initialAmmount, months);
            Assert.Equal(expectedResult, actual);
        }
    }
}
