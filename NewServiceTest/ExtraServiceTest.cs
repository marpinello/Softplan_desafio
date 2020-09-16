namespace ServiceTest
{
    using MainService.Contracts;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;

    public class ExtraServiceTest : IClassFixture<TestSetup>
    {
        private ServiceProvider _serviceProvider;
        private IExtra _extraService;

        public ExtraServiceTest(TestSetup testSetup)
        {
            _serviceProvider = testSetup.ServiceProvider;
            _extraService = _serviceProvider.GetService<IExtra>();
        }

        [Fact]
        public void ShowMeTheCodeShouldReturnTypeString()
        {
            var result = _extraService.ShowMeTheCode();
            Assert.IsType<string>(result);
        }

        [Fact]
        public void ShowMeTheCodeShouldReturnSpecificString()
        {
            var result = _extraService.ShowMeTheCode();
            Assert.Equal("https://github.com/marpinello/Softplan_Desafio", result);
        }
    }
}
