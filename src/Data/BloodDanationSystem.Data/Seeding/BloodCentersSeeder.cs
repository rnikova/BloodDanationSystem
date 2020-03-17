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
                    City = dbContext.Cities.FirstOrDefault(c => c.Name == "София-град"),
                    Address = "ул.Братя Миладинови № 112",
                    Phone = "02/9210 417",
                    Email = "office@ncth.bg",
                    WorkingHours = "понеделник - петък : 8.00-12.00;13.00-18.30 събота, неделя и официални празници : 9.00 - 15.30",
                    EventPhone = "0897320730",
                },
                new BloodCenter
                {
                    Name = "ВМА София",
                    City = dbContext.Cities.FirstOrDefault(c => c.Name == "София-град"),
                    Address = "бул. Св. Георги Софийски № 3",
                    Phone = "02/9226 000",
                    Email = "vma@vma.bg",
                    WorkingHours = "понеделник - петък: 8.30-16.00 неделя: 8.30 - 16.00",
                    EventPhone = "02/9225 512",
                },
                new BloodCenter
                {
                    Name = "София Област - УМБАЛ Света Анна",
                    City = dbContext.Cities.FirstOrDefault(c => c.Name == "София-област"),
                    Address = "София, ж.к. Младост 1,  ул. Димитър Моллов № 1",
                    Phone = "02/975 90 00",
                    Email = "uno@sveta-anna.eu",
                    WorkingHours = "Понеделник - петък: 8.00-13.00",
                    EventPhone = "02/975 90 00",
                },
                new BloodCenter
                {
                    Name = "Сливен",
                    City = dbContext.Cities.FirstOrDefault(c => c.Name == "Сливен"),
                    Address = "ул.Христо Ботев № 1",
                    Phone = "044/ 611 700",
                    Email = "sekretar@mbalsliven.org",
                    WorkingHours = "понеделник-петък: 8.00-15.00",
                    EventPhone = "0887504064",
                },
                new BloodCenter
                {
                    Name = "Хасково",
                    City = dbContext.Cities.FirstOrDefault(c => c.Name == "Хасково"),
                    Address = "бул. Съединение № 49",
                    Phone = "038/624612",
                    Email = "oth_haskovo@abv.bg",
                    WorkingHours = "понеделник-петък: 7.30-13.30",
                    EventPhone = "038/606712",
                },
                new BloodCenter
                {
                    Name = "Кърджали",
                    City = dbContext.Cities.FirstOrDefault(c => c.Name == "Кърджали"),
                    Address = "бул. Беломорски № 53",
                    Phone = "0361/68 333",
                    Email = "hospital_kj@abv.bg",
                    WorkingHours = "понеделник-петък: 7.30-13.00",
                    EventPhone = "0886370976",
                },
                new BloodCenter
                {
                    Name = "Разград",
                    City = dbContext.Cities.FirstOrDefault(c => c.Name == "Разград"),
                    Address = "ул. Коста Петров № 2",
                    Phone = "0893057403",
                    Email = "mbal@bogytec.com",
                    WorkingHours = "понеделник-петък: 8.00-12.30",
                    EventPhone = "084/6243212",
                },
                new BloodCenter
                {
                    Name = "Велико Търново",
                    City = dbContext.Cities.FirstOrDefault(c => c.Name == "Велико Търново"),
                    Address = "ул. Ниш № 1",
                    Phone = "062/626841",
                    Email = "OTH.VT@abv.bg",
                    WorkingHours = "понеделник-петък: 8.00-13.00",
                    EventPhone = "08885482912",
                },
                new BloodCenter
                {
                    Name = "Търговище",
                    City = dbContext.Cities.FirstOrDefault(c => c.Name == "Търговище"),
                    Address = "бул. Сюрен",
                    Phone = "0601/68849",
                    Email = "mbal_trg@mail.bg",
                    WorkingHours = "понеделник-петък: 8.00-13.00",
                    EventPhone = "0601/68849",
                },
                new BloodCenter
                {
                    Name = "РЦТХ Варна",
                    City = dbContext.Cities.FirstOrDefault(c => c.Name == "Варна"),
                    Address = "бул. Цар Освободител № 100",
                    Phone = "052/681801",
                    Email = "rcth_varna@abv.bg",
                    WorkingHours = "понеделник-петък: от 8.00-13.00ч.; 13.30-17.30 ч. събота: 9:00-14:00",
                    EventPhone = "0879533521",
                },
                new BloodCenter
                {
                    Name = "Кюстендил",
                    City = dbContext.Cities.FirstOrDefault(c => c.Name == "Кюстендил"),
                    Address = "площад 17 януари № 1",
                    Phone = "078/550261",
                    Email = "mbal_kn@abv.bg",
                    WorkingHours = "понеделник-петък: 8.00-18.00",
                    EventPhone = "0892095224",
                },
                new BloodCenter
                {
                    Name = "Благоевград",
                    City = dbContext.Cities.FirstOrDefault(c => c.Name == "Благоевград"),
                    Address = "ул. Славянска № 60",
                    Phone = "08795352888",
                    Email = "mbal_bl@abv.bg",
                    WorkingHours = "понеделник-петък: 8.00-14.00 събота: 9:30 - 13:00 с предварителна уговорка",
                    EventPhone = "08795352882",
                },
                new BloodCenter
                {
                    Name = "Бургас",
                    City = dbContext.Cities.FirstOrDefault(c => c.Name == "Бургас"),
                    Address = "бул. Стефан Стамболов № 73",
                    Phone = "056/810565",
                    Email = "dirmbal@abv.bgg",
                    WorkingHours = "понеделник-петък: 7.30-14.30",
                    EventPhone = "056/894866",
                },
                new BloodCenter
                {
                    Name = "Смолян",
                    City = dbContext.Cities.FirstOrDefault(c => c.Name == "Смолян"),
                    Address = "бул. България № 2",
                    Phone = "0301/92 600",
                    Email = "orb-sm@mbox.digsys.bg",
                    WorkingHours = "понеделник-петък: 7.30-15.00",
                    EventPhone = "0889513200",
                },
                new BloodCenter
                {
                    Name = "РЦТХ Пловдив",
                    City = dbContext.Cities.FirstOrDefault(c => c.Name == "Пловдив"),
                    Address = "бул. България № 234Б",
                    Phone = "032/904 401",
                    Email = "rcth_pl@abv.bg",
                    WorkingHours = "понеделник-петък: 8.00-19.00 събота и неделя: 9.00-15.00",
                    EventPhone = "032/904 407",
                },
                new BloodCenter
                {
                    Name = "Ловеч",
                    City = dbContext.Cities.FirstOrDefault(c => c.Name == "Ловеч"),
                    Address = "ул. д-р Съйко Съев № 27",
                    Phone = "068/603381",
                    Email = "mbal_lovech@abv.bg",
                    WorkingHours = "понеделник-петък: 7.30-16.00 събота и неделя: 9.00-16.00",
                    EventPhone = "0888279638",
                },
                new BloodCenter
                {
                    Name = "РЦТХ Плевен",
                    City = dbContext.Cities.FirstOrDefault(c => c.Name == "Плевен"),
                    Address = "бул. Русе № 36",
                    Phone = "064/898848",
                    Email = "rcthpleven@gmail.com",
                    WorkingHours = "понеделник-петък: 7.30-19.30",
                    EventPhone = "064/898835",
                },
                new BloodCenter
                {
                    Name = "Силистра",
                    City = dbContext.Cities.FirstOrDefault(c => c.Name == "Силистра"),
                    Address = "ул. Петър Мутафчиев № 80",
                    Phone = "086818420",
                    Email = "mbalss@abv.bg",
                    WorkingHours = "понеделник-петък: 8.00-13.00",
                    EventPhone = "089876466",
                },
                new BloodCenter
                {
                    Name = "Перник",
                    City = dbContext.Cities.FirstOrDefault(c => c.Name == "Перник"),
                    Address = "ул. Брезник № 2",
                    Phone = "076/688 210",
                    Email = "mbal.pk@abv.bg",
                    WorkingHours = "понеделник-петък: 8.30-13.30",
                    EventPhone = "076/687321",
                },
                new BloodCenter
                {
                    Name = "Видин",
                    City = dbContext.Cities.FirstOrDefault(c => c.Name == "Видин"),
                    Address = "ул. Цар Симеон Велики № 119",
                    Phone = "0887279737",
                    Email = "OTH_Vidin@abv.bg",
                    WorkingHours = "понеделник-петък: 8.00-13.30",
                    EventPhone = "0887279737",
                },
                new BloodCenter
                {
                    Name = "Ямбол",
                    City = dbContext.Cities.FirstOrDefault(c => c.Name == "Ямбол"),
                    Address = "ул. Панайот Хитов № 30",
                    Phone = "046/682 303",
                    Email = "mbal_zop@abv.bg",
                    WorkingHours = "понеделник-събота: 7.30 - 19.30",
                    EventPhone = "0878951299",
                },
                new BloodCenter
                {
                    Name = "РЦТХ Стара Загора",
                    City = dbContext.Cities.FirstOrDefault(c => c.Name == "Стара Загора"),
                    Address = "ул. ген, Столетов № 2",
                    Phone = "042/611 444",
                    Email = "rcth_st_zagora@abv.bg",
                    WorkingHours = "понеделник-петък: 7.30-14.30",
                    EventPhone = "0878840163",
                },
                new BloodCenter
                {
                    Name = "Пазарджик",
                    City = dbContext.Cities.FirstOrDefault(c => c.Name == "Пазарджик"),
                    Address = "ул. Болнична № 15",
                    Phone = "0882 805 617",
                    Email = "mbalpz@gmail.com",
                    WorkingHours = "понеделник-петък: 7.30-13.00",
                    EventPhone = "0882805617",
                },
                new BloodCenter
                {
                    Name = "Русе",
                    City = dbContext.Cities.FirstOrDefault(c => c.Name == "Русе"),
                    Address = "площад Независимост № 2",
                    Phone = "082/887 228",
                    Email = "mbalruse@mail.bg",
                    WorkingHours = "понеделник-петък: 7.30-12.30",
                    EventPhone = "082/887 236",
                },
                new BloodCenter
                {
                    Name = "Габрово",
                    City = dbContext.Cities.FirstOrDefault(c => c.Name == "Габрово"),
                    Address = "Д-р Илиев–Детския № 1",
                    Phone = "066/800253",
                    Email = "mbalgab@gmail.com",
                    WorkingHours = "понеделник-петък: 8.00-19.00",
                    EventPhone = "0885378338",
                },
                new BloodCenter
                {
                    Name = "Шумен",
                    City = dbContext.Cities.FirstOrDefault(c => c.Name == "Шумен"),
                    Address = "ул. Васил Априлов № 63",
                    Phone = "054/800924",
                    Email = "mbal-shumen@ro-ni.net",
                    WorkingHours = "понеделник - петък: 7.30-13.00",
                    EventPhone = "0882901845",
                },
                new BloodCenter
                {
                    Name = "Добрич",
                    City = dbContext.Cities.FirstOrDefault(c => c.Name == "Добрич"),
                    Address = "ул. Панайот Хитов № 24",
                    Phone = "058/600 690",
                    Email = "oth_dobrich1952@abv.bg",
                    WorkingHours = "понеделник-петък: 8.00-12.30",
                    EventPhone = "0884540994",
                },
                new BloodCenter
                {
                    Name = "Лом",
                    City = dbContext.Cities.FirstOrDefault(c => c.Name == "Лом"),
                    Address = "ул. Тодор Каблешков № 2",
                    Phone = "0879215530",
                    Email = "oth_lom@abv.bg",
                    WorkingHours = "понеделник-петък: 8.00-15.00 четвъртък : 8:00-13:00",
                    EventPhone = "0971/600 51",
                },
                new BloodCenter
                {
                    Name = "Враца",
                    City = dbContext.Cities.FirstOrDefault(c => c.Name == "Враца"),
                    Address = "бул. 2 юни № 66",
                    Phone = "0884999532",
                    Email = "mbal_vratza@abv.bg",
                    WorkingHours = "понеделник-петък: 7.30-13.30",
                    EventPhone = "0888989843",
                },
            };

            for (int i = 0; i < bloodCenters.Count; i++)
            {
                bloodCenters[i].Id = i + 1;
                await dbContext.BloodCenters.AddAsync(bloodCenters[i]);
            }
        }
    }
}
