namespace BloodDanationSystem.Services.Tests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using BloodDanationSystem.Data;
    using BloodDanationSystem.Data.Models;
    using BloodDanationSystem.Data.Repositories;
    using BloodDanationSystem.Services.Tests.Common;
    using BloodDanationSystem.Services.Tests.Seeders;
    using BloodDonationSystem.Services.Models;
    using BloodDonationSystem.Services.Models.DonorsPatientsServiceModel;
    using BloodDonationSystem.Services.Models.Patients;
    using BloodDonationSystem.Services.Models.Users;
    using Microsoft.AspNetCore.Identity;
    using Moq;
    using Xunit;

    public class DonorsPatientsServiceTests
    {
        [Fact]
        public async Task CreateAsync_WithCorectData_ShouldReturnCorectResult()
        {
            var errorMessage = "DonorsPatientsService CreateAsync method does not return properly ";

            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var seeder = new Seeder();
            await seeder.SeedDonorAsync(context);
            await seeder.SeedPatientAsync(context);
            var userManager = this.GetUserManagerMock(context);
            var patientRepository = new EfDeletableEntityRepository<Patient>(context);
            var patientService = new PatientService(patientRepository, context, userManager.Object);
            var donorPatientRepository = new EfDeletableEntityRepository<DonorsPatients>(context);
            var donorsPatientsService = new DonorsPatientsService(donorPatientRepository, context, patientService, userManager.Object);
            var donor = context.Donors.First();
            var patient = context.Patients.First();

            var donorsPatientsServiceModel = new DonorsPatientsServiceModel
            {
                DonorId = donor.Id,
                PatientId = patient.Id,
            };

            var result = await donorsPatientsService.CreateAsync(donorsPatientsServiceModel);
            var actualResult = context.DonorsPatients.FirstOrDefault();
            var expectedResult = donorsPatientsServiceModel;

            Assert.True(result);
            Assert.True(actualResult.DonorId == expectedResult.DonorId, errorMessage + "DonorId");
            Assert.True(actualResult.PatientId == expectedResult.PatientId, errorMessage + "PatientId");
        }

        [Fact]
        public async Task GetDonorsPatientsByDonorsUserIdAsync_WithCorectData_ShouldReturnCorectResult()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var seeder = new Seeder();
            await seeder.SeedDonorsPatientsAsync(context);
            var userManager = this.GetUserManagerMock(context);
            var patientRepository = new EfDeletableEntityRepository<Patient>(context);
            var patientService = new PatientService(patientRepository, context, userManager.Object);
            var donorPatientRepository = new EfDeletableEntityRepository<DonorsPatients>(context);
            var donorsPatientsService = new DonorsPatientsService(donorPatientRepository, context, patientService, userManager.Object);

            var actualResult = await donorsPatientsService.GetDonorsPatientsByDonorsUserIdAsync("userId1");
            var expectedResult = context.DonorsPatients.Where(x => x.Donor.UserId == "userId1" && x.IsDeleted == false).FirstOrDefault();

            Assert.True(expectedResult.DonorId == actualResult.DonorId);
            Assert.True(expectedResult.PatientId == actualResult.PatientId);
        }

        [Fact]
        public async Task GetDonorsPatientsByDonorsUserIdAsync_WithIncorectUserId_ShouldThrowException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var seeder = new Seeder();
            await seeder.SeedDonorsPatientsAsync(context);
            var userManager = this.GetUserManagerMock(context);
            var patientRepository = new EfDeletableEntityRepository<Patient>(context);
            var patientService = new PatientService(patientRepository, context, userManager.Object);
            var donorPatientRepository = new EfDeletableEntityRepository<DonorsPatients>(context);
            var donorsPatientsService = new DonorsPatientsService(donorPatientRepository, context, patientService, userManager.Object);

            await Assert.ThrowsAsync<NullReferenceException>(async () =>
            {
                await donorsPatientsService.GetDonorsPatientsByDonorsUserIdAsync("invalidId");
            });
        }

        [Fact]
        public async Task GetDonorsPatientsByPatientsUserIdAsync_WithCorectData_ShouldReturnCorectResult()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var seeder = new Seeder();
            await seeder.SeedDonorsPatientsAsync(context);
            var userManager = this.GetUserManagerMock(context);
            var patientRepository = new EfDeletableEntityRepository<Patient>(context);
            var patientService = new PatientService(patientRepository, context, userManager.Object);
            var donorPatientRepository = new EfDeletableEntityRepository<DonorsPatients>(context);
            var donorsPatientsService = new DonorsPatientsService(donorPatientRepository, context, patientService, userManager.Object);

            var actualResult = await donorsPatientsService.GetDonorsPatientsByPatientsUserIdAsync("userId2");
            var expectedResult = context.DonorsPatients.Where(x => x.Patient.UserId == "userId2" && x.IsDeleted == false).FirstOrDefault();

            Assert.True(expectedResult.DonorId == actualResult.DonorId);
            Assert.True(expectedResult.PatientId == actualResult.PatientId);
            Assert.True(expectedResult.Image == actualResult.Image);
        }

        [Fact]
        public async Task GetDonorsPatientsByPatiensUserIdAsync_WithIncorectUserId_ShouldThrowException()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var seeder = new Seeder();
            await seeder.SeedDonorsPatientsAsync(context);
            var userManager = this.GetUserManagerMock(context);
            var patientRepository = new EfDeletableEntityRepository<Patient>(context);
            var patientService = new PatientService(patientRepository, context, userManager.Object);
            var donorPatientRepository = new EfDeletableEntityRepository<DonorsPatients>(context);
            var donorsPatientsService = new DonorsPatientsService(donorPatientRepository, context, patientService, userManager.Object);

            await Assert.ThrowsAsync<NullReferenceException>(async () =>
            {
                await donorsPatientsService.GetDonorsPatientsByPatientsUserIdAsync("invalidId");
            });
        }

        [Fact]
        public async Task AddImageAsync_WithCorectData_ShouldReturnCorectResult()
        {
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var seeder = new Seeder();
            await seeder.SeedDonorsPatientsAsync(context);
            var userManager = this.GetUserManagerMock(context);
            var patientRepository = new EfDeletableEntityRepository<Patient>(context);
            var patientService = new PatientService(patientRepository, context, userManager.Object);
            var donorPatientRepository = new EfDeletableEntityRepository<DonorsPatients>(context);
            var donorsPatientsService = new DonorsPatientsService(donorPatientRepository, context, patientService, userManager.Object);
            var donorPatient = context.DonorsPatients.First();
            var donorsPatientsServiceModel = new DonorsPatientsServiceModel
            {
                DonorId = donorPatient.DonorId,
                PatientId = donorPatient.PatientId,
            };

            var actualResult = await donorsPatientsService.AddImageAsync(donorsPatientsServiceModel, "url");
            var expectedResult = donorsPatientsServiceModel;

            Assert.True(actualResult);
        }

        [Fact]
        public async Task DeleteDonorsPatientAsync_ShouldDeleteSuccessfully()
        {
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var seeder = new Seeder();
            await seeder.SeedDonorsPatientsAsync(context);
            var userManager = this.GetUserManagerMock(context);
            var patientRepository = new EfDeletableEntityRepository<Patient>(context);
            var patientService = new PatientService(patientRepository, context, userManager.Object);
            var donorPatientRepository = new EfDeletableEntityRepository<DonorsPatients>(context);
            var donorsPatientsService = new DonorsPatientsService(donorPatientRepository, context, patientService, userManager.Object);
            var donorPatient = context.DonorsPatients.First();
            await userManager.Object.AddToRoleAsync(donorPatient.Donor.User, "Donor");
            await userManager.Object.AddToRoleAsync(donorPatient.Patient.User, "Patient");
            var donorsPatientsServiceModel = new DonorsPatientsServiceModel
            {
                DonorId = donorPatient.DonorId,
                PatientId = donorPatient.PatientId,
                Donor = new DonorServiceModel
                {
                    User = new UserServiceModel
                    {
                        Id = donorPatient.Donor.User.Id,
                    },
                },
                Patient = new PatientServiceModel
                {
                    User = new UserServiceModel
                    {
                        Id = donorPatient.Patient.User.Id,
                    },
                },
            };

            var actualResult = await donorsPatientsService.DeleteDonorsPatientAsync(donorsPatientsServiceModel);

            Assert.True(actualResult);
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
