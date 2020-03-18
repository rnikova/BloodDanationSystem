namespace BloodDanationSystem.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BloodDanationSystem.Data.Models;

    public class HospitalsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Hospitals.Any())
            {
                return;
            }

            var hospitals = new List<Hospital>
            {
                new Hospital
                {
                    Name = "МБАЛ Благоевград АД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Благоевград").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ - Иван Скендеров ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Гоце Делчев").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ Разлог ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Разлог").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ Пулс АД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Благоевград").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ Рокфелер ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Петрич").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ Югозападна болница ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Сандански").Id,
                },
                new Hospital
                {
                    Name = "СБАЛО Свети Мина ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Благоевград").Id,
                },
                new Hospital
                {
                    Name = "Аджибадем Сити Клиник СБАЛК - Бургас ООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Бургас").Id,
                },
                new Hospital
                {
                    Name = "КОЦ - Бургас ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Бургас").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ - Лайф Хоспитал ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Бургас").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ Д-р Маджуров ООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Бургас").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ Бургасмед ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Пещера").Id,
                },
                new Hospital
                {
                    Name = "СОБАЛ - Бургас ООДД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Бургас").Id,
                },
                new Hospital
                {
                    Name = "СХБАЛ ООД - гр. БургасД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Бургас").Id,
                },
                new Hospital
                {
                    Name = "УМБАЛ Бургас АД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Бургас").Id,
                },
                new Hospital
                {
                    Name = "УМБАЛ - Дева Мария ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Бургас").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ Варна",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Варна").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ - Еврохоспитал ООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Варна").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ Света Анна - Варна АД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Варна").Id,
                },
                new Hospital
                {
                    Name = "УМБАЛ Света Марина ЕАД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Варна").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ Майчин дом - Варна ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Варна").Id,
                },
                new Hospital
                {
                    Name = "СБАЛ по кардиология ЕАД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Варна").Id,
                },
                new Hospital
                {
                    Name = "СБАГАЛ Проф. д-р Димитър Стаматов - Варна ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Варна").Id,
                },
                new Hospital
                {
                    Name = "СБАЛДБ - доктор Лисичкова ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Варна").Id,
                },
                new Hospital
                {
                    Name = "СБАЛК - Кардиолайф ООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Варна").Id,
                },
                new Hospital
                {
                    Name = "СБАЛОЗ Д-р Марко Антонов Марков - Варна ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Варна").Id,
                },
                new Hospital
                {
                    Name = "СБОБАЛ Варна ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Варна").Id,
                },
                new Hospital
                {
                    Name = "СОБАЛ - доц. Георгиев ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Варна").Id,
                },
                new Hospital
                {
                    Name = "СХБАЛ - проф. Темелков ООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Варна").Id,
                },
                new Hospital
                {
                    Name = "КОЦ - Велико Търново ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Велико Търново").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ - Павликени ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Павликени").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ д-р Димитър Павлович ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Свищов").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ Св. Иван Рилски ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Горна Оряховица").Id,
                },
                new Hospital
                {
                    Name = "МОБАЛ Д-р Ст. Черкезов АД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Велико Търново").Id,
                },
                new Hospital
                {
                    Name = "СБАЛК ЕАД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Велико Търново").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ - Белоградчик ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Белоградчик").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ Св. Петка АД ",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Видин").Id,
                },
                new Hospital
                {
                    Name = "КОЦ - Враца ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Враца").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ - Бяла слатина ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Бяла Слатина").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ - Мездра ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Мездра").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ - Христо Ботев АД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Враца").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ Вива Медика ООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Враца").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ Свети Иван Рилски - Козлодуй ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Козлодуй").Id,
                },
                new Hospital
                {
                    Name = "ПЧМБАЛ - Враца ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Враца").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ д-р Ст. Христов ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Севлиево").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ - Д-р Теодоси Витанов ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Трявна").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ Акта Медика ООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Севлиево").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ Д-р Тота Венкова АД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Габрово").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ - Балчик ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Балчик").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ - Каварна ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Каварна").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ- Добрич АД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Добрич").Id,
                },
                new Hospital
                {
                    Name = "СХБАЛ - Медика ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Албена").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ - Ардино ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Ардино").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ - д-р Атанас Дафовски АД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Кърджали").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ - Живот+ ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Крумовград").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ - Кърджали ООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Кърджали").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ Сергей Ростовцев ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Момчилград").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ Св. Иван Рилски - 2003 ООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Дупница").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ Свети Иван Рилски ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Дупница").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ - д-р Никола Василев АД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Кюстендил").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ - Проф. д-р Параскев Стоянов АД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Ловеч").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ - Луковит ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Луковит").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ - Троян ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Троян").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ- Тетевен - д-р Ангел Пешев ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Тетевен").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ - Берковица ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Берковица").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ - Свети Николай Чудотворец - Лом ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Лом").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ Д-р Стамен Илиев АД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Монтана").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ Сити Клиник - Свети Георги ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Монтана").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ - Берковица ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Берковица").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ Велинград ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Велинград").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ Ескулап ООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Пазарджик").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ Здраве - Велинград ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Велинград").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ Здраве ООД - Пазарджик, филиал на МБАЛ Пълмед ООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Пазарджик").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ Пазарджик АД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Пазарджик").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ - УНИ ХОСПИТАЛ ООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Панагюрище").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ Хигия АД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Пазарджик").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ Хигия - Север ООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Пазарджик").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ Рахила Ангелова АД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Перник").Id,
                },
                new Hospital
                {
                    Name = "СХБАЛ - Еврика ООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Перник").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ Авис-Медика ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Плевен").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ Св. Панталеймон - Плевен ООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Плевен").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ „Света Параскева“ ООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Плевен").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ Сърце и Мозък ЕАД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Плевен").Id,
                },
                new Hospital
                {
                    Name = "УМБАЛ Св. Марина ООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Плевен").Id,
                },
                new Hospital
                {
                    Name = "УМБАЛ д-р Г. Странски ЕАД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Плевен").Id,
                },
                new Hospital
                {
                    Name = "СБАЛК ЕАД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Плевен").Id,
                },
                new Hospital
                {
                    Name = "КОЦ - Пловдив ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Пловдив").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ - Асеновград ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Асеновград").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ - МК Св. Иван Рилски ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Пловдив").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ - Пловдив АД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Пловдив").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ - Първомай ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Първомай").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ Д-р Киро Попов ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Карлово").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ Мед Лайн Клиник АД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Пловдив").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ Св. Мина - Пловдив ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Пловдив").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ Света Каридад ЕАД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Пловдив").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ Свети Пантелеймон ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Пловдив").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ Тримонциум ООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Пловдив").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ Централ Онко Хоспитал ООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Пловдив").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ Св. Св. Козма и Дамян ООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Пловдив").Id,
                },
                new Hospital
                {
                    Name = "Медикус Алфа СХБАЛ ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Пловдив").Id,
                },
                new Hospital
                {
                    Name = "УМБАЛ - Еврохоспитал Пловдив ООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Пловдив").Id,
                },
                new Hospital
                {
                    Name = "УМБАЛ - Каспела ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Пловдив").Id,
                },
                new Hospital
                {
                    Name = "УМБАЛ Пълмед ООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Пловдив").Id,
                },
                new Hospital
                {
                    Name = "УМБАЛ Свети Георги ЕАД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Пловдив").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ - Кубрат ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Кубрат").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ Св. Иван Рилски - Разград АД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Разград").Id,
                },
                new Hospital
                {
                    Name = "КОЦ - Русе ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Русе").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ - Юлия Вревска - Бяла ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Бяла").Id,
                },
                new Hospital
                {
                    Name = "УМБАЛ Канев АД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Русе").Id,
                },
                new Hospital
                {
                    Name = "УМБАЛ Медика Русе ООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Русе").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ - Дулово ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Дулово").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ - Силистра АД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Силистра").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ - Тутракан ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Тутракан").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ Д-р Иван Селимински - Сливен АД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Сливен").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ Хаджи Димитър ООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Сливен").Id,
                },
                new Hospital
                {
                    Name = "СХБАЛ - Амброаз Паре ООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Сливен").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ - Девин ЕАД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Девин").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ - Проф. д-р Константин Чилов ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Мадан").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ Д-р Братан Шукеров АД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Смолян").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ Проф. д-р Асен Шопов ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Златоград").Id,
                },
                new Hospital
                {
                    Name = "Аджибадем Сити Клиник УМБАЛ ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "София").Id,
                },
                new Hospital
                {
                    Name = "Аджибадем Сити Клиник МБАЛ Токуда ЕАД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "София").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ - Вита ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "София").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ - Доверие АД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "София").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ - Света София ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "София").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ БОЛНИЦА ЕВРОПА ООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "София").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ за женско здраве - Надежда ООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "София").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ Здравето 2012 ООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "София").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ НКБ ЕАД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "София").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ Света Богородица ООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "София").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ Свети Панталеймон - София АД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "София").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ Сердика ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "София").Id,
                },
                new Hospital
                {
                    Name = "Пета МБАЛ - София ЕАД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "София").Id,
                },
                new Hospital
                {
                    Name = "Първа МБАЛ - София ЕАД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "София").Id,
                },
                new Hospital
                {
                    Name = "СБАЛ на деца с онкохематологични заболявания - София ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "София").Id,
                },
                new Hospital
                {
                    Name = "СБАЛ по ортопедия и травматология Витоша ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "София").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ Полимед ООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "София").Id,
                },
                new Hospital
                {
                    Name = "СБАЛАГ - Майчин дом ЕАД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "София").Id,
                },
                new Hospital
                {
                    Name = "СБАЛЛЧХ ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "София").Id,
                },
                new Hospital
                {
                    Name = "СОБАЛ - Бул-Про ЕАД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "София").Id,
                },
                new Hospital
                {
                    Name = "Четвърта МБАЛ - София ЕАД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "София").Id,
                },
                new Hospital
                {
                    Name = "I-ва САГБАЛ Света София ЕАД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "София").Id,
                },
                new Hospital
                {
                    Name = "СБАЛ по ДЛЧХ - Медикрон ООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "София").Id,
                },
                new Hospital
                {
                    Name = "УМБАЛ - Александровска ЕАД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "София").Id,
                },
                new Hospital
                {
                    Name = "УМБАЛСМ Н. И. Пирогов ЕАД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "София").Id,
                },
                new Hospital
                {
                    Name = "УМБАЛ Св. Иван Рилски ЕАД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "София").Id,
                },
                new Hospital
                {
                    Name = "УМБАЛ Света Екатерина ЕАД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "София").Id,
                },
                new Hospital
                {
                    Name = "УМБАЛ Софиямед ООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "София").Id,
                },
                new Hospital
                {
                    Name = "УМБАЛ Царица Йоанна - ИСУЛ ЕАД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "София").Id,
                },
                new Hospital
                {
                    Name = "УСБАЛ по ендокринология Акад. Иван Пенчев ЕАД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "София").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ - Ботевград ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Ботевград").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ - Ихтиман ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Ихтиман").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ - Пирдоп АД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Пирдоп").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ - Самоков ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Самоков").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ - Своге ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Своге").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ Проф. д-р Александър Герчев - Етрополе ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Етрополе").Id,
                },
                new Hospital
                {
                    Name = "УМБАЛ Света Анна АД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "София").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ СКИН СИСТЕМС ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Доганово").Id,
                },
                new Hospital
                {
                    Name = "СБАЛОЗ - София област ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "София").Id,
                },
                new Hospital
                {
                    Name = "КОЦ - Стара Загора ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Стара Загора").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ - Д-р Христо Стамболски ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Казанлък").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ - Доктор Димитър Чакмаков - Раднево ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Раднево").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ - МК Св. Иван Рилски ЕООД - клон Стара Загора",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Стара Загора").Id,
                },
                new Hospital
                {
                    Name = "УМБАЛ - Проф. Ст. Киркович АД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Стара Загора").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ - Чирпан ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Чирпан").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ ЕАД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Гълъбово").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ Ниамед ООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Стара Загора").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ ТРАКИЯ ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Стара Загора").Id,
                },
                new Hospital
                {
                    Name = "СХБАЛ - Ритъм РР ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Стара Загора").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ - Омуртаг ЕАД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Омуртаг").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ - Търговище АД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Търговище").Id,
                },
                new Hospital
                {
                    Name = "СХБАЛ Папуров ООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Търговище").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ - Свиленград ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Свиленград").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ - Харманли ЕООДД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Харманли").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ - Хасково АД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Хасково").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ Св. Екатерина - Димитровград ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Димитровград").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ Хигия ООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Хасково").Id,
                },
                new Hospital
                {
                    Name = "СБАЛ по онкология - Хасково ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Хасково").Id,
                },
                new Hospital
                {
                    Name = "КОЦ - Шумен ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Шумен").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ - Шумен АД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Шумен").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ Д-р Добри Беров ЕООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Нови Пазар").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ Св. Йоан Рилски ООД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Ямбол").Id,
                },
                new Hospital
                {
                    Name = "МБАЛ Св. Пантелеймон АД",
                    CityId = dbContext.Cities.FirstOrDefault(c => c.Name == "Ямбол").Id,
                },
            };

            for (int i = 0; i < hospitals.Count; i++)
            {
                await dbContext.Hospitals.AddAsync(hospitals[i]);
            }
        }
    }
}
