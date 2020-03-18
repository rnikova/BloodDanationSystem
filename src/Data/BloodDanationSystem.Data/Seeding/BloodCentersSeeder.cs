namespace BloodDanationSystem.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BloodDanationSystem.Data.Models;

    public class BloodCentersSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.BloodCenters.Any())
            {
                return;
            }

            var bloodCenters = new List<BloodCenter>
            {
                new BloodCenter
                {
                    Name = "НЦТХ София",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "София").Id,
                    Address = "ул.Братя Миладинови № 112",
                    Phone = "02/9210 417",
                    Email = "office@ncth.bg",
                    WorkingHours = "понеделник - петък : 8.00-12.00;13.00-18.30 събота, неделя и официални празници : 9.00 - 15.30",
                    EventPhone = "0897320730",
                },
                new BloodCenter
                {
                    Name = "ВМА София",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "София").Id,
                    Address = "бул. Св. Георги Софийски № 3",
                    Phone = "02/9226 000",
                    Email = "vma@vma.bg",
                    WorkingHours = "понеделник - петък: 8.30-16.00 неделя: 8.30 - 16.00",
                    EventPhone = "02/9225 512",
                },
                new BloodCenter
                {
                    Name = "София Област - УМБАЛ Света Анна",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "София").Id,
                    Address = "София, ж.к. Младост 1,  ул. Димитър Моллов № 1",
                    Phone = "02/975 90 00",
                    Email = "uno@sveta-anna.eu",
                    WorkingHours = "Понеделник - петък: 8.00-13.00",
                    EventPhone = "02/975 90 00",
                },
                new BloodCenter
                {
                    Name = "Сливен",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Сливен").Id,
                    Address = "ул.Христо Ботев № 1",
                    Phone = "044/ 611 700",
                    Email = "sekretar@mbalsliven.org",
                    WorkingHours = "понеделник-петък: 8.00-15.00",
                    EventPhone = "0887504064",
                },
                new BloodCenter
                {
                    Name = "Хасково",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Хасково").Id,
                    Address = "бул. Съединение № 49",
                    Phone = "038/624612",
                    Email = "oth_haskovo@abv.bg",
                    WorkingHours = "понеделник-петък: 7.30-13.30",
                    EventPhone = "038/606712",
                },
                new BloodCenter
                {
                    Name = "Кърджали",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Кърджали").Id,
                    Address = "бул. Беломорски № 53",
                    Phone = "0361/68 333",
                    Email = "hospital_kj@abv.bg",
                    WorkingHours = "понеделник-петък: 7.30-13.00",
                    EventPhone = "0886370976",
                },
                new BloodCenter
                {
                    Name = "Разград",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Разград").Id,
                    Address = "ул. Коста Петров № 2",
                    Phone = "0893057403",
                    Email = "mbal@bogytec.com",
                    WorkingHours = "понеделник-петък: 8.00-12.30",
                    EventPhone = "084/6243212",
                },
                new BloodCenter
                {
                    Name = "Велико Търново",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Велико Търново").Id,
                    Address = "ул. Ниш № 1",
                    Phone = "062/626841",
                    Email = "OTH.VT@abv.bg",
                    WorkingHours = "понеделник-петък: 8.00-13.00",
                    EventPhone = "08885482912",
                },
                new BloodCenter
                {
                    Name = "Търговище",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Търговище").Id,
                    Address = "бул. Сюрен",
                    Phone = "0601/68849",
                    Email = "mbal_trg@mail.bg",
                    WorkingHours = "понеделник-петък: 8.00-13.00",
                    EventPhone = "0601/68849",
                },
                new BloodCenter
                {
                    Name = "РЦТХ Варна",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Варна").Id,
                    Address = "бул. Цар Освободител № 100",
                    Phone = "052/681801",
                    Email = "rcth_varna@abv.bg",
                    WorkingHours = "понеделник-петък: от 8.00-13.00ч.; 13.30-17.30 ч. събота: 9:00-14:00",
                    EventPhone = "0879533521",
                },
                new BloodCenter
                {
                    Name = "Кюстендил",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Кюстендил").Id,
                    Address = "площад 17 януари № 1",
                    Phone = "078/550261",
                    Email = "mbal_kn@abv.bg",
                    WorkingHours = "понеделник-петък: 8.00-18.00",
                    EventPhone = "0892095224",
                },
                new BloodCenter
                {
                    Name = "Благоевград",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Благоевград").Id,
                    Address = "ул. Славянска № 60",
                    Phone = "08795352888",
                    Email = "mbal_bl@abv.bg",
                    WorkingHours = "понеделник-петък: 8.00-14.00 събота: 9:30 - 13:00 с предварителна уговорка",
                    EventPhone = "08795352882",
                },
                new BloodCenter
                {
                    Name = "Бургас",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Бургас").Id,
                    Address = "бул. Стефан Стамболов № 73",
                    Phone = "056/810565",
                    Email = "dirmbal@abv.bgg",
                    WorkingHours = "понеделник-петък: 7.30-14.30",
                    EventPhone = "056/894866",
                },
                new BloodCenter
                {
                    Name = "Смолян",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Смолян").Id,
                    Address = "бул. България № 2",
                    Phone = "0301/92 600",
                    Email = "orb-sm@mbox.digsys.bg",
                    WorkingHours = "понеделник-петък: 7.30-15.00",
                    EventPhone = "0889513200",
                },
                new BloodCenter
                {
                    Name = "РЦТХ Пловдив",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Пловдив").Id,
                    Address = "бул. България № 234Б",
                    Phone = "032/904 401",
                    Email = "rcth_pl@abv.bg",
                    WorkingHours = "понеделник-петък: 8.00-19.00 събота и неделя: 9.00-15.00",
                    EventPhone = "032/904 407",
                },
                new BloodCenter
                {
                    Name = "Ловеч",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Ловеч").Id,
                    Address = "ул. д-р Съйко Съев № 27",
                    Phone = "068/603381",
                    Email = "mbal_lovech@abv.bg",
                    WorkingHours = "понеделник-петък: 7.30-16.00 събота и неделя: 9.00-16.00",
                    EventPhone = "0888279638",
                },
                new BloodCenter
                {
                    Name = "РЦТХ Плевен",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Плевен").Id,
                    Address = "бул. Русе № 36",
                    Phone = "064/898848",
                    Email = "rcthpleven@gmail.com",
                    WorkingHours = "понеделник-петък: 7.30-19.30",
                    EventPhone = "064/898835",
                },
                new BloodCenter
                {
                    Name = "Силистра",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Силистра").Id,
                    Address = "ул. Петър Мутафчиев № 80",
                    Phone = "086818420",
                    Email = "mbalss@abv.bg",
                    WorkingHours = "понеделник-петък: 8.00-13.00",
                    EventPhone = "089876466",
                },
                new BloodCenter
                {
                    Name = "Перник",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Перник").Id,
                    Address = "ул. Брезник № 2",
                    Phone = "076/688 210",
                    Email = "mbal.pk@abv.bg",
                    WorkingHours = "понеделник-петък: 8.30-13.30",
                    EventPhone = "076/687321",
                },
                new BloodCenter
                {
                    Name = "Видин",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Видин").Id,
                    Address = "ул. Цар Симеон Велики № 119",
                    Phone = "0887279737",
                    Email = "OTH_Vidin@abv.bg",
                    WorkingHours = "понеделник-петък: 8.00-13.30",
                    EventPhone = "0887279737",
                },
                new BloodCenter
                {
                    Name = "Ямбол",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Ямбол").Id,
                    Address = "ул. Панайот Хитов № 30",
                    Phone = "046/682 303",
                    Email = "mbal_zop@abv.bg",
                    WorkingHours = "понеделник-събота: 7.30 - 19.30",
                    EventPhone = "0878951299",
                },
                new BloodCenter
                {
                    Name = "РЦТХ Стара Загора",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Стара Загора").Id,
                    Address = "ул. ген, Столетов № 2",
                    Phone = "042/611 444",
                    Email = "rcth_st_zagora@abv.bg",
                    WorkingHours = "понеделник-петък: 7.30-14.30",
                    EventPhone = "0878840163",
                },
                new BloodCenter
                {
                    Name = "Пазарджик",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Пазарджик").Id,
                    Address = "ул. Болнична № 15",
                    Phone = "0882 805 617",
                    Email = "mbalpz@gmail.com",
                    WorkingHours = "понеделник-петък: 7.30-13.00",
                    EventPhone = "0882805617",
                },
                new BloodCenter
                {
                    Name = "Русе",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Русе").Id,
                    Address = "площад Независимост № 2",
                    Phone = "082/887 228",
                    Email = "mbalruse@mail.bg",
                    WorkingHours = "понеделник-петък: 7.30-12.30",
                    EventPhone = "082/887 236",
                },
                new BloodCenter
                {
                    Name = "Габрово",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Габрово").Id,
                    Address = "Д-р Илиев–Детския № 1",
                    Phone = "066/800253",
                    Email = "mbalgab@gmail.com",
                    WorkingHours = "понеделник-петък: 8.00-19.00",
                    EventPhone = "0885378338",
                },
                new BloodCenter
                {
                    Name = "Шумен",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Шумен").Id,
                    Address = "ул. Васил Априлов № 63",
                    Phone = "054/800924",
                    Email = "mbal-shumen@ro-ni.net",
                    WorkingHours = "понеделник - петък: 7.30-13.00",
                    EventPhone = "0882901845",
                },
                new BloodCenter
                {
                    Name = "Добрич",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Добрич").Id,
                    Address = "ул. Панайот Хитов № 24",
                    Phone = "058/600 690",
                    Email = "oth_dobrich1952@abv.bg",
                    WorkingHours = "понеделник-петък: 8.00-12.30",
                    EventPhone = "0884540994",
                },
                new BloodCenter
                {
                    Name = "Лом",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Лом").Id,
                    Address = "ул. Тодор Каблешков № 2",
                    Phone = "0879215530",
                    Email = "oth_lom@abv.bg",
                    WorkingHours = "понеделник-петък: 8.00-15.00 четвъртък : 8:00-13:00",
                    EventPhone = "0971/600 51",
                },
                new BloodCenter
                {
                    Name = "Враца",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Враца").Id,
                    Address = "бул. 2 юни № 66",
                    Phone = "0884999532",
                    Email = "mbal_vratza@abv.bg",
                    WorkingHours = "понеделник-петък: 7.30-13.30",
                    EventPhone = "0888989843",
                },
            };

            for (int i = 0; i < bloodCenters.Count; i++)
            {
                await dbContext.BloodCenters.AddAsync(bloodCenters[i]);
            }
        }
    }
}
