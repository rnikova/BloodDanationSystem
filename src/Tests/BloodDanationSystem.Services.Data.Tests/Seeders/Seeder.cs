namespace BloodDanationSystem.Services.Tests.Seeders
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BloodDanationSystem.Data;
    using BloodDanationSystem.Data.Models;
    using BloodDanationSystem.Data.Models.Enums;

    public class Seeder
    {
        public async Task SeedUsersAsync(ApplicationDbContext context)
        {
            var firstUser = new ApplicationUser
            {
                FullName = "First User",
                Age = 22,
                UserName = "firstUser",
            };
            var secondUser = new ApplicationUser
            {
                FullName = "Second User",
                Age = 22,
                UserName = "secondUser",
            };

            await context.Users.AddAsync(firstUser);
            await context.Users.AddAsync(secondUser);
            await context.SaveChangesAsync();
        }

        public async Task SeedBloodTypesAsync(ApplicationDbContext context)
        {
            var bloodTypes = new List<BloodType>
            {
                new BloodType
                {
                    ABOGroupName = ABOGroup.А,
                    RhesusFactor = RhesusFactor.Плюс,
                },
                new BloodType
                {
                    ABOGroupName = ABOGroup.В,
                    RhesusFactor = RhesusFactor.Минус,
                },
                new BloodType
                {
                    ABOGroupName = ABOGroup.АВ,
                    RhesusFactor = RhesusFactor.БезЗначение,
                },
                new BloodType
                {
                    ABOGroupName = ABOGroup.О,
                    RhesusFactor = RhesusFactor.Неизвестен,
                },
            };

            await context.BloodTypes.AddRangeAsync(bloodTypes);
            await context.SaveChangesAsync();
        }

        public async Task SeedPatientAsync(ApplicationDbContext context)
        {
            var patients = new List<Patient>
            {
                new Patient
                {
                    FullName = "First User",
                    Age = 22,
                    BloodTypeId = 1,
                    UserId = "userId1",
                    HospitalId = 1,
                    Ward = "ward1",
                    NeededBloodBanks = 3,
                },
                new Patient
                {
                    FullName = "Second User",
                    Age = 22,
                    BloodTypeId = 1,
                    UserId = "userId2",
                    HospitalId = 2,
                    Ward = "ward2",
                    NeededBloodBanks = 0,
                },
            };

            await context.Patients.AddRangeAsync(patients);
            await context.SaveChangesAsync();
        }
    }
}
