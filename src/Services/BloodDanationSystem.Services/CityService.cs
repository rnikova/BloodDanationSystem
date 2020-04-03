namespace BloodDanationSystem.Services
{
    using System.Linq;

    using BloodDanationSystem.Data;
    using BloodDanationSystem.Services.Mapping;
    using BloodDonationSystem.Services.Models.Cities;

    public class CityService : ICityService
    {
        private readonly ApplicationDbContext context;

        public CityService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IQueryable<CityServiceModel> AllCities()
        {
            return this.context.Cities.OrderBy(x => x.Name).To<CityServiceModel>();
        }
    }
}
