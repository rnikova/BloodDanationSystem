namespace BloodDanationSystem.Services.Tests
{
    using System.Linq;
    using System.Threading.Tasks;

    using BloodDanationSystem.Services.Tests.Common;
    using BloodDanationSystem.Services.Tests.Seeders;
    using BloodDonationSystem.Services.Models.Cities;
    using Xunit;

    public class CityServiceTests
    {
        [Fact]
        public async Task AllCities_ShouldReturnCorectData()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var seeder = new Seeder();
            await seeder.SeedCities(context);
            var cityService = new CityService(context);

            var actualResult = cityService.AllCities().Result;
            var expectedResult = context.Cities;

            Assert.NotNull(actualResult);
            Assert.True(actualResult.Count() == expectedResult.Count());
            Assert.IsAssignableFrom<IQueryable<CityServiceModel>>(actualResult);
        }
    }
}
