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

        public async Task SeedCities(ApplicationDbContext context)
        {
            var cities = new List<City>
            {
                new City
                {
                    Name = "София",
                },
                new City
                {
                    Name = "Пловдив",
                },
            };

            await context.Cities.AddRangeAsync(cities);
            await context.SaveChangesAsync();
        }

        public async Task SeedDonorAsync(ApplicationDbContext context)
        {
            var donors = new List<Donor>
            {
                new Donor
                {
                    FullName = "First User",
                    Age = 22,
                    BloodTypeId = 1,
                    UserId = "userId1",
                    CityId = 1,
                },
                new Donor
                {
                    FullName = "Second User",
                    Age = 22,
                    BloodTypeId = 1,
                    UserId = "userId2",
                    CityId = 2,
                },
            };

            await context.Donors.AddRangeAsync(donors);
            await context.SaveChangesAsync();
        }

        public async Task SeedDonorsPatientsAsync(ApplicationDbContext context)
        {
            var donorsPatients = new List<DonorsPatients>
            {
                new DonorsPatients
                {
                    DonorId = "donorId1",
                    Donor = new Donor
                    {
                        FullName = "First User",
                        Age = 22,
                        BloodTypeId = 1,
                        UserId = "userId1",
                        CityId = 1,
                    },
                    PatientId = "patientId1",
                    Patient = new Patient
                    {
                        FullName = "Second User",
                        Age = 22,
                        BloodTypeId = 1,
                        UserId = "userId3",
                        HospitalId = 2,
                        Ward = "ward2",
                        NeededBloodBanks = 3,
                    },
                    Image = "image",
                },
                new DonorsPatients
                {
                    DonorId = "donorId2",
                    Donor = new Donor
                    {
                        FullName = "Second User",
                        Age = 22,
                        BloodTypeId = 1,
                        UserId = "userId2",
                        CityId = 2,
                    },
                    PatientId = "patientId2",
                    Patient = new Patient
                    {
                        FullName = "Second User",
                        Age = 22,
                        BloodTypeId = 1,
                        UserId = "userId2",
                        HospitalId = 2,
                        Ward = "ward2",
                        NeededBloodBanks = 3,
                    },
                    Image = "image2",
                },
            };

            await context.DonorsPatients.AddRangeAsync(donorsPatients);
            await context.SaveChangesAsync();
        }
    }
}
