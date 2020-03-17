namespace BloodDanationSystem.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BloodDanationSystem.Data.Models;

    public class CitiesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Cities.Any())
            {
                return;
            }

            var cities = new List<string>
            {
                "Благоевград",
                "Бургас",
                "Варна",
                "Велико Търново",
                "Видин",
                "Враца",
                "Габрово",
                "Добрич",
                "Кърджали",
                "Кюстендил",
                "Ловеч",
                "Монтана",
                "Пазарджик",
                "Перник",
                "Плевен",
                "Пловдив",
                "Разград",
                "Русе",
                "Силистра",
                "Сливен",
                "Смолян",
                "София-град",
                "София-област",
                "Стара Загора",
                "Търговище",
                "Хасково",
                "Шумен",
                "Ямбол",
                "Лом",
            };

            for (int i = 0; i < cities.Count; i++)
            {
                await dbContext.Cities.AddAsync(new City
                {
                    Id = i + 1,
                    Name = cities[i],
                });
            }
        }
    }
}
