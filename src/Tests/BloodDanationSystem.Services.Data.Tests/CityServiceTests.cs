namespace BloodDanationSystem.Services.Tests
{
    using System.Linq;
    using System.Threading.Tasks;

    using BloodDanationSystem.Data;
    using BloodDanationSystem.Data.Models;
    using BloodDanationSystem.Data.Repositories;
    using BloodDanationSystem.Services.Tests.Common;
    using BloodDanationSystem.Services.Tests.Seeders;
    using BloodDonationSystem.Services.Models.Cities;
    using Microsoft.Data.Sqlite;
    using Microsoft.EntityFrameworkCore;
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
            var cityRepository = new EfDeletableEntityRepository<City>(context);
            var cityService = new CityService(cityRepository);

            var actualResult = cityService.AllCities();
            var expectedResult = context.Cities;

            Assert.NotNull(actualResult);
            Assert.True(actualResult.Result.Count() == expectedResult.Count());
            Assert.IsAssignableFrom<IQueryable<CityServiceModel>>(actualResult);
        }
    }
}
