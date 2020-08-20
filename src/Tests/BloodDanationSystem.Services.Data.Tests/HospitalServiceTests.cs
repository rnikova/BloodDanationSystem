namespace BloodDanationSystem.Services.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BloodDanationSystem.Data.Models;
    using BloodDanationSystem.Data.Repositories;
    using BloodDanationSystem.Services.Tests.Common;
    using BloodDanationSystem.Services.Tests.Seeders;
    using BloodDonationSystem.Services.Models.Hospitals;
    using Xunit;

    public class HospitalServiceTests
    {
        [Fact]
        public async Task AllHospitals_ShouldReturnCorectData()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var seeder = new Seeder();
            await seeder.SeedHospitals(context);
            var hospitalRepository = new EfDeletableEntityRepository<Hospital>(context);
            var hospitalService = new HospitalService(hospitalRepository, context);

            var actualResult = hospitalService.AllHospitals().Result;
            var expectedResult = context.Hospitals;

            Assert.True(actualResult.Count() == expectedResult.Count());
            Assert.IsAssignableFrom<IQueryable<HospitalServiceModel>>(actualResult);
        }

        [Fact]
        public async Task HospitalsInCity_ShouldReturnCorectData()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var seeder = new Seeder();
            await seeder.SeedHospitals(context);
            var hospitalRepository = new EfDeletableEntityRepository<Hospital>(context);
            var hospitalService = new HospitalService(hospitalRepository, context);

            var actualResult = hospitalService.HospitalsInCity(1);
            var expectedResult = context.Hospitals.Where(x => x.CityId == 1);

            Assert.NotNull(actualResult);
            Assert.IsAssignableFrom<IEnumerable<HospitalServiceModel>>(actualResult);
        }
    }
}
