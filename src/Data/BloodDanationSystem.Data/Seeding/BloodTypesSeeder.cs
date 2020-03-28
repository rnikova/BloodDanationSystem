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
                    ABOGroupName = ABOGroup.O,
                    RhesusFactor = RhesusFactor.Plus,
                },
                new BloodType
                {
                    ABOGroupName = ABOGroup.O,
                    RhesusFactor = RhesusFactor.Minus,
                },
                new BloodType
                {
                    ABOGroupName = ABOGroup.O,
                    RhesusFactor = RhesusFactor.NoMatter,
                },
                new BloodType
                {
                    ABOGroupName = ABOGroup.O,
                    RhesusFactor = RhesusFactor.Unknown,
                },
                new BloodType
                {
                    ABOGroupName = ABOGroup.A,
                    RhesusFactor = RhesusFactor.Plus,
                },
                new BloodType
                {
                    ABOGroupName = ABOGroup.A,
                    RhesusFactor = RhesusFactor.Minus,
                },
                new BloodType
                {
                    ABOGroupName = ABOGroup.A,
                    RhesusFactor = RhesusFactor.NoMatter,
                },
                new BloodType
                {
                    ABOGroupName = ABOGroup.A,
                    RhesusFactor = RhesusFactor.Unknown,
                },
                new BloodType
                {
                    ABOGroupName = ABOGroup.B,
                    RhesusFactor = RhesusFactor.Plus,
                },
                new BloodType
                {
                    ABOGroupName = ABOGroup.B,
                    RhesusFactor = RhesusFactor.Minus,
                },
                new BloodType
                {
                    ABOGroupName = ABOGroup.B,
                    RhesusFactor = RhesusFactor.NoMatter,
                },
                new BloodType
                {
                    ABOGroupName = ABOGroup.B,
                    RhesusFactor = RhesusFactor.Unknown,
                },
                new BloodType
                {
                    ABOGroupName = ABOGroup.AB,
                    RhesusFactor = RhesusFactor.Plus,
                },
                new BloodType
                {
                    ABOGroupName = ABOGroup.AB,
                    RhesusFactor = RhesusFactor.Minus,
                },
                new BloodType
                {
                    ABOGroupName = ABOGroup.AB,
                    RhesusFactor = RhesusFactor.NoMatter,
                },
                new BloodType
                {
                    ABOGroupName = ABOGroup.AB,
                    RhesusFactor = RhesusFactor.Unknown,
                },
            };

            for (int i = 0; i < bloodTypes.Count; i++)
            {
                await dbContext.BloodTypes.AddAsync(bloodTypes[i]);
            }
        }
    }
}
