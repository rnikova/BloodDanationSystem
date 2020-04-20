namespace BloodDanationSystem.Services.Tests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using BloodDanationSystem.Data;
    using BloodDanationSystem.Data.Models;
    using BloodDanationSystem.Services.Mapping;
    using BloodDanationSystem.Services.Tests.Common;
    using BloodDanationSystem.Services.Tests.Seeders;
    using BloodDonationSystem.Services.Models;
    using BloodDonationSystem.Services.Models.Users;
    using Microsoft.AspNetCore.Identity;
    using Moq;
    using Xunit;

    public class DonorServiceTests
    {
        [Theory]
        [InlineData("Иван Иванов Иванов", 33, "А", "Плюс", 1)]
        public async Task CreateAsync_WithCorectData_ShouldReturnCorectResult(string fullName, int age, string aboGroup, string rhesusFactor, int city)
        {
            var errorMessage = "DonorService CreateAsync method does not return properly ";

            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var seeder = new Seeder();
            await seeder.SeedUsersAsync(context);
            await seeder.SeedBloodTypesAsync(context);
            await seeder.SeedCities(context);
            var userManager = this.GetUserManagerMock(context);
            var donorService = new DonorService(context, userManager.Object);

            var donorServiceModel = new DonorServiceModel
            {
                FullName = fullName,
                Age = age,
                BloodType = new BloodDonationSystem.Services.Models.BloodTypeServiceModel
                {
                    ABOGroupName = aboGroup,
                    RhesusFactor = rhesusFactor,
                },
                UserId = context.Users.First().Id,
                CityId = city,
            };

            var result = await donorService.CreateAsync(donorServiceModel);
            var actualResult = context.Donors.FirstOrDefault();
            var expectedResult = donorServiceModel;

            Assert.True(result);
            Assert.True(actualResult.FullName == expectedResult.FullName, errorMessage + "FullName");
            Assert.True(actualResult.Age == expectedResult.Age, errorMessage + "Age");
            Assert.True(actualResult.BloodType.ABOGroupName.ToString() == expectedResult.BloodType.ABOGroupName.ToString(), errorMessage + "ABOGroup");
            Assert.True(actualResult.BloodType.RhesusFactor.ToString() == expectedResult.BloodType.RhesusFactor.ToString(), errorMessage + "RhesusFactor");
            Assert.True(actualResult.UserId == expectedResult.UserId, errorMessage + "UserId");
            Assert.True(actualResult.CityId == expectedResult.CityId, errorMessage + "CityId");
        }

        [Theory]
        [InlineData(null, 33, "А", "Плюс", 1)]
        [InlineData("", 33, "А", "Плюс", 1)]
        [InlineData(" ", 33, "А", "Плюс", 1)]
        [InlineData("Donor", 33, null, "Плюс", 1)]
        [InlineData("Donor", 33, null, null, 1)]
        public async Task CreateAsync_WithIncorectData_ShouldThrowException(string fullName, int age, string aboGroup, string rhesusFactor, int city)
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var seeder = new Seeder();
            await seeder.SeedUsersAsync(context);
            await seeder.SeedBloodTypesAsync(context);
            await seeder.SeedCities(context);
            var userManager = this.GetUserManagerMock(context);
            var donorService = new DonorService(context, userManager.Object);

            var donorServiceModel = new DonorServiceModel
            {
                FullName = fullName,
                Age = age,
                BloodType = new BloodDonationSystem.Services.Models.BloodTypeServiceModel
                {
                    ABOGroupName = aboGroup,
                    RhesusFactor = rhesusFactor,
                },
                UserId = context.Users.First().Id,
                CityId = city,
            };

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await donorService.CreateAsync(donorServiceModel);
            });
        }

        [Fact]
        public async Task All_ShouldReturnCorectData()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var seeder = new Seeder();
            await seeder.SeedDonorAsync(context);
            var userManager = this.GetUserManagerMock(context);
            var donorService = new DonorService(context, userManager.Object);

            var actualResult = donorService.All();
            var expectedResult = context.Donors;

            Assert.True(actualResult.Count() == expectedResult.Count());
            Assert.IsAssignableFrom<IQueryable<DonorServiceModel>>(actualResult);
        }

        [Fact]
        public async Task GetByUserIdAsync_ShouldReturn_CorectDonor()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var seeder = new Seeder();
            await seeder.SeedDonorAsync(context);
            var userManager = this.GetUserManagerMock(context);
            var donorService = new DonorService(context, userManager.Object);

            var actualResult = await donorService.GetByUserIdAsync("userId1");

            Assert.True(actualResult.UserId == "userId1");
        }

        [Fact]
        public async Task GetByUserIdAsync_ShouldThrownException_WithInvalidUser()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var seeder = new Seeder();
            await seeder.SeedDonorAsync(context);
            var userManager = this.GetUserManagerMock(context);
            var donorService = new DonorService(context, userManager.Object);

            await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await donorService.GetByUserIdAsync("invalidId");
            });
        }

        private Mock<UserManager<ApplicationUser>> GetUserManagerMock(ApplicationDbContext context)
        {
            var userStoreMock = new Mock<IUserStore<ApplicationUser>>();
            var userManagerMock = new Mock<UserManager<ApplicationUser>>(
                userStoreMock.Object, null, null, null, null, null, null, null, null);
            userManagerMock
                .Setup(x => x.UpdateAsync(It.IsAny<ApplicationUser>()))
                .Callback((ApplicationUser user) =>
                {
                    context.Update(user);
                })
                .ReturnsAsync(IdentityResult.Success);

            return userManagerMock;
        }
    }
}
