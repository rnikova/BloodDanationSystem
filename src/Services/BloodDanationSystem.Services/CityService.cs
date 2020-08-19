namespace BloodDanationSystem.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BloodDanationSystem.Data;
    using BloodDanationSystem.Data.Models;
    using BloodDanationSystem.Data.Repositories;
    using BloodDanationSystem.Services.Mapping;
    using BloodDonationSystem.Services.Models.Cities;
    using Microsoft.EntityFrameworkCore;

    public class CityService : ICityService
    {
        private readonly EfDeletableEntityRepository<City> citiesRepository;

        public CityService(EfDeletableEntityRepository<City> citiesRepository)
        {
            this.citiesRepository = citiesRepository;
        }

        public async Task<IEnumerable<CityServiceModel>> AllCities()
        {
            return await this.citiesRepository
                .AllAsNoTracking()
                .OrderBy(x => x.Name)
                .To<CityServiceModel>()
                .ToListAsync();
        }
    }
}
