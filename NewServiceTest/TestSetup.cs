using MainService.Contracts;
using MainService.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ServiceTest
{
    public class TestSetup
    {
        public TestSetup()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<ICalc, CalcService>();
            serviceCollection.AddTransient<IExtra, ExtraService>();
            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        public ServiceProvider ServiceProvider { get; private set; }
    }
}
