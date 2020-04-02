namespace BloodDanationSystem.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BloodDanationSystem.Data.Models;
    using BloodDanationSystem.Data.Models.Enums;

    public class BloodTypesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.BloodTypes.Any())
            {
                return;
            }

            var bloodTypes = new List<BloodType>
            {
                new BloodType
                {
                    ABOGroupName = ABOGroup.О,
                    RhesusFactor = RhesusFactor.Плюс,
                },
                new BloodType
                {
                    ABOGroupName = ABOGroup.О,
                    RhesusFactor = RhesusFactor.Минус,
                },
                new BloodType
                {
                    ABOGroupName = ABOGroup.О,
                    RhesusFactor = RhesusFactor.БезЗначение,
                },
                new BloodType
                {
                    ABOGroupName = ABOGroup.О,
                    RhesusFactor = RhesusFactor.Неизвестен,
                },
                new BloodType
                {
                    ABOGroupName = ABOGroup.А,
                    RhesusFactor = RhesusFactor.Плюс,
                },
                new BloodType
                {
                    ABOGroupName = ABOGroup.А,
                    RhesusFactor = RhesusFactor.Минус,
                },
                new BloodType
                {
                    ABOGroupName = ABOGroup.А,
                    RhesusFactor = RhesusFactor.БезЗначение,
                },
                new BloodType
                {
                    ABOGroupName = ABOGroup.А,
                    RhesusFactor = RhesusFactor.Неизвестен,
                },
                new BloodType
                {
                    ABOGroupName = ABOGroup.В,
                    RhesusFactor = RhesusFactor.Плюс,
                },
                new BloodType
                {
                    ABOGroupName = ABOGroup.В,
                    RhesusFactor = RhesusFactor.Минус,
                },
                new BloodType
                {
                    ABOGroupName = ABOGroup.В,
                    RhesusFactor = RhesusFactor.БезЗначение,
                },
                new BloodType
                {
                    ABOGroupName = ABOGroup.В,
                    RhesusFactor = RhesusFactor.Неизвестен,
                },
                new BloodType
                {
                    ABOGroupName = ABOGroup.АВ,
                    RhesusFactor = RhesusFactor.Плюс,
                },
                new BloodType
                {
                    ABOGroupName = ABOGroup.АВ,
                    RhesusFactor = RhesusFactor.Минус,
                },
                new BloodType
                {
                    ABOGroupName = ABOGroup.АВ,
                    RhesusFactor = RhesusFactor.БезЗначение,
                },
                new BloodType
                {
                    ABOGroupName = ABOGroup.АВ,
                    RhesusFactor = RhesusFactor.Неизвестен,
                },
            };

            for (int i = 0; i < bloodTypes.Count; i++)
            {
                await dbContext.BloodTypes.AddAsync(bloodTypes[i]);
            }
        }
    }
}
