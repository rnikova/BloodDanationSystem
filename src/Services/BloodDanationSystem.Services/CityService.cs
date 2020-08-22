namespace BloodDanationSystem.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BloodDanationSystem.Data;
    using BloodDanationSystem.Services.Mapping;
    using BloodDonationSystem.Services.Models.Cities;
    using Microsoft.EntityFrameworkCore;

    public class CityService : ICityService
    {
        private readonly ApplicationDbContext context;

        public CityService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<CityServiceModel>> AllCities()
        {
            return await this.context
                .Cities
                .AsNoTracking()
                .OrderBy(x => x.Name)
                .To<CityServiceModel>().ToListAsync();
        }
    }
}
