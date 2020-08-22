namespace BloodDanationSystem.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BloodDanationSystem.Data;
    using BloodDanationSystem.Services.Mapping;
    using BloodDonationSystem.Services.Models.Hospitals;
    using Microsoft.EntityFrameworkCore;

    public class HospitalService : IHospitalService
    {
        private readonly ApplicationDbContext context;

        public HospitalService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<HospitalServiceModel>> AllHospitals()
        {
            return await this.context
                .Hospitals
                .AsNoTracking()
                .To<HospitalServiceModel>()
                .ToListAsync();
        }

        public async Task<IEnumerable<HospitalServiceModel>> HospitalsInCity(int cityId)
        {
            return await this.context
                .Hospitals
                .AsNoTracking()
                .Where(x => x.CityId == cityId)
                .To<HospitalServiceModel>()
                .ToListAsync();
        }
    }
}
