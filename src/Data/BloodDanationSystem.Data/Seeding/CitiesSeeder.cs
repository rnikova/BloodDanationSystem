﻿namespace BloodDanationSystem.Data.Seeding
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
                "Гоце Делчев",
                "Разлог",
                "Петрич",
                "Сандански",
                "Бургас",
                "Пещера",
                "Варна",
                "Велико Търново",
                "Павликени",
                "Свищов",
                "Горна Оряховица",
                "Белоградчик",
                "Видин",
                "Враца",
                "Бяла Слатина",
                "Мездра",
                "Козлодуй",
                "Севлиево",
                "Трявна",
                "Габрово",
                "Балчик",
                "Каварна",
                "Албена",
                "Ардино",
                "Добрич",
                "Кърджали",
                "Крумовград",
                "Момчилград",
                "Дупница",
                "Кюстендил",
                "Ловеч",
                "Луковит",
                "Троян",
                "Тетевен",
                "Берковица",
                "Лом",
                "Монтана",
                "Велинград",
                "Пазарджик",
                "Панагюрище",
                "Перник",
                "Плевен",
                "Пловдив",
                "Асеновград",
                "Първомай",
                "Кубрат",
                "Разград",
                "Русе",
                "Бяла",
                "Дулово",
                "Силистра",
                "Тутракан",
                "Сливен",
                "Девин",
                "Мадан",
                "Смолян",
                "Златоград",
                "София",
                "Ботевград",
                "Ихтиман",
                "Пирдоп",
                "Самоков",
                "Своге",
                "Етрополе",
                "Доганово",
                "Стара Загора",
                "Казанлък",
                "Раднево",
                "Чирпан",
                "Гълъбово",
                "Омуртаг",
                "Търговище",
                "Свиленград",
                "Харманли",
                "Хасково",
                "Димитровград",
                "Шумен",
                "Нови Пазар",
                "Ямбол",
                "Карлово",
                "Търговище",
            };

            for (int i = 0; i < cities.Count; i++)
            {
                await dbContext.Cities.AddAsync(new City
                {
                    Name = cities[i],
                });
            }
        }
    }
}
