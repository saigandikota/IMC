using Microsoft.Extensions.Configuration;
using IMC.API.DTO;
using IMC.API.Integrations;
using IMC.API.Services.Controllers;
using NUnit.Framework;
using Microsoft.Extensions.DependencyInjection;
using IMC.API.Services;

namespace TaxService_UnitTest
{
    public class TaxServiceTest
    {
        int zipCode;
        Rate rate = null;
        private readonly IConfiguration configuration;
        TaxServiceController controller = null;

                [SetUp]
        public void Setup()
        {
            ConfigureServices_RegistersDependenciesCorrectly();
        }

        public void ConfigureServices_RegistersDependenciesCorrectly()
        {
            //  Arrange
            IServiceCollection services = new ServiceCollection();
            var target = new Startup(configuration);

            //  Act
            target.ConfigureServices(services);
            //  Mimic internal asp.net core logic.
            services.AddTransient<TaxServiceController>();
            services.AddSingleton<ITaxjarService, TaxjarService>();
            var serviceProvider = services.BuildServiceProvider();
            controller = serviceProvider.GetService<TaxServiceController>();

            //  Assert
            Assert.IsNotNull(controller);
        }

        [Test]
        public void TaxForOrder_Returns_TaxInfo_For_A_Given_Order()
        {
            //Arrange
            zipCode = 33331;
            //Act
            rate= controller.GetTaxRateByLocation(zipCode);

            //Assert
            Assert.IsNotNull(rate);
        }

        [Test]
        public void Get_TaxRates_For_A_Given_Location()
        {
            //Arrange

            //Act

            //Assert
            Assert.Pass();
        }
    }
}