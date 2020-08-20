namespace BloodDanationSystem.Services.Tests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using BloodDanationSystem.Data;
    using BloodDanationSystem.Data.Models;
    using BloodDanationSystem.Data.Repositories;
    using BloodDanationSystem.Services;
    using BloodDanationSystem.Services.Tests.Common;
    using BloodDanationSystem.Services.Tests.Seeders;
    using BloodDonationSystem.Services.Models.Patients;
    using Microsoft.AspNetCore.Identity;
    using Moq;
    using Xunit;

    public class PatientServiceTests
    {
        [Theory]
        [InlineData("Иван Иванов Иванов", 33, "А", "Плюс", 2, 3, "Отделение")]
        [InlineData("Иван Иванов Иванов", 33, "А", "Плюс", 2, 1, "Отделение")]
        [InlineData("Иван Иванов Иванов", 33, "А", "Плюс", 2, 10, "Отделение")]
        public async Task CreateAsync_WithCorectData_ShouldReturnCorectResult(string fullName, int age, string aboGroup, string rhesusFactor, int hospitalId, int neededBloodBanks, string ward)
        {
            var errorMessage = "PatientService CreateAsync method does not return properly ";

            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var seeder = new Seeder();
            await seeder.SeedUsersAsync(context);
            await seeder.SeedBloodTypesAsync(context);
            var userManager = this.GetUserManagerMock(context);
            var patientRepository = new EfDeletableEntityRepository<Patient>(context);
            var patientService = new PatientService(patientRepository, context, userManager.Object);

            var patientServiceModel = new PatientServiceModel
            {
                FullName = fullName,
                Age = age,
                BloodType = new BloodDonationSystem.Services.Models.BloodTypeServiceModel
                {
                    ABOGroupName = aboGroup,
                    RhesusFactor = rhesusFactor,
                },
                HospitalId = hospitalId,
                NeededBloodBanks = neededBloodBanks,
                Ward = ward,
                UserId = context.Users.First().Id,
            };

            var result = await patientService.CreateAsync(patientServiceModel);
            var actualResult = context.Patients.FirstOrDefault();
            var expectedResult = patientServiceModel;

            Assert.True(result);
            Assert.True(actualResult.FullName == expectedResult.FullName, errorMessage + "FullName");
            Assert.True(actualResult.Age == expectedResult.Age, errorMessage + "Age");
            Assert.True(actualResult.BloodType.ABOGroupName.ToString() == expectedResult.BloodType.ABOGroupName.ToString(), errorMessage + "ABOGroup");
            Assert.True(actualResult.BloodType.RhesusFactor.ToString() == expectedResult.BloodType.RhesusFactor.ToString(), errorMessage + "RhesusFactor");
            Assert.True(actualResult.HospitalId == expectedResult.HospitalId, errorMessage + "HospitalId");
            Assert.True(actualResult.NeededBloodBanks == expectedResult.NeededBloodBanks, errorMessage + "NeededBloodBanks");
            Assert.True(actualResult.Ward == expectedResult.Ward, errorMessage + "Ward");
            Assert.True(actualResult.UserId == expectedResult.UserId, errorMessage + "UserId");
        }

        [Theory]
        [InlineData("", 33, "А", "Плюс", 2, 1, "Отделение")]
        [InlineData(null, 33, "А", "Плюс", 2, 1, "Отделение")]
        [InlineData("Ivan", 33, null, "Плюс", 2, 1, "Отделение")]
        [InlineData("Ivan", 33, "А", null, 2, 1, "Отделение")]
        [InlineData("Ivan", 33, "А", "Плюс", 2, 11, "Отделение")]
        [InlineData("Ivan", 33, "А", "Плюс", 2, 0, "Отделение")]
        [InlineData("Ivan", 33, "А", "Плюс", 2, 1, "")]
        [InlineData("Ivan", 33, "А", "Плюс", 2, 1, null)]
        public async Task CreateAsync_ShouldThrowException_WithInvalidData(string fullName, int age, string aboGroup, string rhesusFactor, int hospitalId, int neededBloodBanks, string ward)
        {
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var seeder = new Seeder();
            await seeder.SeedUsersAsync(context);
            await seeder.SeedBloodTypesAsync(context);
            var userManager = this.GetUserManagerMock(context);
            var patientRepository = new EfDeletableEntityRepository<Patient>(context);
            var patientService = new PatientService(patientRepository, context, userManager.Object);

            var patientServiceModel = new PatientServiceModel
            {
                FullName = fullName,
                Age = age,
                BloodType = new BloodDonationSystem.Services.Models.BloodTypeServiceModel
                {
                    ABOGroupName = aboGroup,
                    RhesusFactor = rhesusFactor,
                },
                HospitalId = hospitalId,
                NeededBloodBanks = neededBloodBanks,
                Ward = ward,
                UserId = context.Users.First().Id,
            };

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await patientService.CreateAsync(patientServiceModel);
            });
        }

        [Fact]
        public async Task All_ShouldReturnCorectData()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var seeder = new Seeder();
            await seeder.SeedPatientAsync(context);
            var userManager = this.GetUserManagerMock(context);
            var patientRepository = new EfDeletableEntityRepository<Patient>(context);
            var patientService = new PatientService(patientRepository, context, userManager.Object);

            var actualResult = patientService.All().Result;
            var expectedResult = context.Patients;

            Assert.True(actualResult.Count() == expectedResult.Count());
            Assert.IsAssignableFrom<IQueryable<PatientServiceModel>>(actualResult);
        }

        [Fact]
        public async Task AllActive_ShouldReturnCorectData()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var seeder = new Seeder();
            await seeder.SeedPatientAsync(context);
            var userManager = this.GetUserManagerMock(context);
            var patientRepository = new EfDeletableEntityRepository<Patient>(context);
            var patientService = new PatientService(patientRepository, context, userManager.Object);

            var actualResult = patientService.AllActive().Result;
            var expectedResult = context.Patients.Where(x => x.NeededBloodBanks > 0);

            Assert.True(actualResult.Count() == expectedResult.Count());
            Assert.IsAssignableFrom<IQueryable<PatientServiceModel>>(actualResult);
        }

        [Fact]
        public async Task GetByUserIdAsync_ShouldReturn_CorectPatient()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var seeder = new Seeder();
            await seeder.SeedPatientAsync(context);
            var userManager = this.GetUserManagerMock(context);
            var patientRepository = new EfDeletableEntityRepository<Patient>(context);
            var patientService = new PatientService(patientRepository, context, userManager.Object);

            var actualResult = await patientService.GetByUserIdAsync("userId1");

            Assert.True(actualResult.UserId == "userId1");
        }

        [Fact]
        public async Task GetByUserIdAsync_ShouldThrow_NullReferenceException_WithNonExistentUser()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var seeder = new Seeder();
            await seeder.SeedPatientAsync(context);
            var userManager = this.GetUserManagerMock(context);
            var patientRepository = new EfDeletableEntityRepository<Patient>(context);
            var patientService = new PatientService(patientRepository, context, userManager.Object);

            await Assert.ThrowsAsync<NullReferenceException>(async () =>
            {
                await patientService.GetByUserIdAsync("invalidId");
            });
        }

        [Fact]
        public async Task GetByPatientIdAsync_ShouldReturn_CorectPatient()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var seeder = new Seeder();
            await seeder.SeedPatientAsync(context);
            var userManager = this.GetUserManagerMock(context);
            var patientRepository = new EfDeletableEntityRepository<Patient>(context);
            var patientService = new PatientService(patientRepository, context, userManager.Object);

            var expectedResult = context.Patients.First();
            var actualResult = await patientService.GetByPatientIdAsync(expectedResult.Id);

            Assert.Equal(expectedResult.Id, actualResult.Id);
            Assert.True(actualResult.UserId == expectedResult.UserId);
            Assert.True(actualResult.GetType() == typeof(PatientServiceModel));
        }

        [Fact]
        public async Task GetByUserIdAsync_ShouldThrow_NullReferenceException_WithNonExistentPatient()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var seeder = new Seeder();
            await seeder.SeedPatientAsync(context);
            var userManager = this.GetUserManagerMock(context);
            var patientRepository = new EfDeletableEntityRepository<Patient>(context);
            var patientService = new PatientService(patientRepository, context, userManager.Object);

            await Assert.ThrowsAsync<NullReferenceException>(async () =>
            {
                await patientService.GetByPatientIdAsync("invalidId");
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
